using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerScript : MonoBehaviour
{
    public LogicManager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touch");
        logic.addScore(1);
    }
}
