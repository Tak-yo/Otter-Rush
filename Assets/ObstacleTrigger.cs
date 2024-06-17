using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerScript : MonoBehaviour
{
    public LogicManager logic;
    // public float HitboxNumber;
    // private float currentHits;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        // currentHits = HitboxNumber;    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch");
        // currentHits -= 1;
        // if (currentHits == 0){
            logic.addScore(1);
        //     currentHits = HitboxNumber;
        // }
        
    }
}
