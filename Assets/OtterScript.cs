using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;



public class OtterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpHeight = 6;
    public float spins = 2;
    public bool isOtterAlive = true;
    public bool isOtterGrounded = true;
    public bool isOtterRunning = true;
    public LogicManager logic;
    public enum animState{
        RUN,
        JUMP,
        LAND,
        SPIN,
        SLEEP
    };
    public Animator otterAnimator;
    animState otterState = animState.RUN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if otter is out of bounds
        if (3.13f < transform.position.y ){
            myRigidBody.velocity = new Vector2(0,0);
            myRigidBody.gravityScale = 0;
        }
        //otter animation state machine (i realise halfway that cos its only one button press you can actually hardcode the whole thing but it's already up so ohwellz)

        switch (otterState){

            case animState.RUN:

                if (Input.GetKeyDown(KeyCode.Space) && isOtterAlive){
                    myRigidBody.velocity = Vector2.up * jumpHeight;
                    Debug.Log("Jumped");
                    otterAnimator.SetTrigger("Jump");
                    isOtterGrounded = false;
                    otterState = animState.JUMP;
                }
                
                break;

            case animState.JUMP:

                if (isOtterGrounded){
                    Debug.Log("Landed");
                    otterAnimator.SetTrigger("Run");
                    otterState = animState.RUN;
                }

                break;

            // case animState.LAND:

            //     if (isOtterRunning){
            //         Debug.Log("Running");
            //         otterAnimator.SetTrigger("Run");
            //         otterState = animState.RUN;
            //     }

                break;
            case animState.SPIN:

                if (spins == 0){
                    Debug.Log("Sleeping");
                    otterAnimator.SetTrigger("Spun");
                    otterState = animState.SLEEP;
                }

                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        // death of otter;
        if (target.gameObject.CompareTag("Obstacle"))
        {
            logic.gameOver();
            Debug.Log("Dead");
            isOtterAlive = false;
            otterAnimator.SetTrigger("Death");
            otterState = animState.SPIN;
        }

        if (target.gameObject.CompareTag("Ground"))
        {
            isOtterGrounded = true;
            Debug.Log("Grounded");
        }
    } 

    public void otterRun(){
        isOtterRunning = true;
    }

    public void otterSpin(){
        spins -= 1;
    }
}
