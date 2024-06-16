using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
    private float deadZone = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MoveSpeed *Time.deltaTime;
        if (transform.position.x < deadZone){
            Debug.Log("Obstacle Deleted");
            Destroy(gameObject);
        }
    }
}
