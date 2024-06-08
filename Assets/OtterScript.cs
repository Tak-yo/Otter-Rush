using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;



public class OtterScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpHeight = 6;
    public bool isOtterAlive = true;
    public bool isOtterGrounded = true;
    public enum animState{
        RUN,
        JUMP,
        LAND
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
                    otterAnimator.SetTrigger("Land");
                    isOtterGrounded = false;
                    otterState = animState.LAND;
                }

                break;

            case animState.LAND:

                if (otterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5){
                    Debug.Log("Running");
                    otterAnimator.SetTrigger("Run");
                    isOtterGrounded = false;
                    otterState = animState.RUN;
                }

                break;

        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        // logic.gameOver();
        if (target.gameObject.tag.Equals("Obstacle")){
            Debug.Log("Dead");
            isOtterAlive = false;
        }

        if (target.gameObject.tag.Equals("Ground")){
            isOtterGrounded = !isOtterGrounded;
            Debug.Log("Grounded");
        }
    } 

}
