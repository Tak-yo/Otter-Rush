using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleMoveScript : MonoBehaviour
{
    public OtterScript otter;
    public float MoveSpeed = 5;
    private float deadZone = -20;
    // Start is called before the first frame update
    void Start()
    {
        otter = GameObject.FindGameObjectWithTag("Otter").GetComponent<OtterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (otter.isOtterAlive){
            transform.position += Vector3.left * MoveSpeed *Time.deltaTime;
            if (transform.position.x < deadZone){
                Debug.Log("Obstacle Deleted");
                Destroy(gameObject);
            }
        }
    }
}
