using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 0.5f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{ 
            spawnObstacle();
            timer = 0;
            if (spawnRate < 0.5){
                spawnRate *= UnityEngine.Random.Range(1.1f,2);
            }
            else{
                spawnRate *= UnityEngine.Random.Range(0.9f,1);
            }
        }
    }

    void spawnObstacle(){
        Instantiate(obstacle, position: new Vector3(transform.position.x, transform.position.y, 0),transform.rotation);
    }
}
