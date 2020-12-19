using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class monsterControl : MonoBehaviour
{

    public GameObject target;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject monster;
    private int ran;
    private int time=0;

    public GameObject player;
    public UnityEngine.AI.NavMeshAgent nvAgent;
    // Start is called before the first frame update
    void Start()
    {
        nvAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        System.Random r = new System.Random();

        // Methods:

        ran = r.Next(1, 4);  // 최소 min 값 부터 최대 max - 1 까지

        if (ran == 1)
        {
            nvAgent.SetDestination(point1.transform.position);

        }
        else if (ran == 2)
        {
            nvAgent.SetDestination(point2.transform.position);

        }
        else if (ran == 3)
        {
            nvAgent.SetDestination(point3.transform.position);

        }
        else if (ran == 4)
        {
            nvAgent.SetDestination(point4.transform.position);

        }


    }
    
    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(monster.transform.position, player.transform.position);

        // Radom class:

        // Radom class:
        System.Random r = new System.Random();

        // Methods:

        ran = r.Next(1,4);  // 최소 min 값 부터 최대 max - 1 까지




        if (dist <5)
        {
            nvAgent.SetDestination(player.transform.position);
        }
        else
        {
            if (time < 1000)
            {
                time++;

            }
            else
            {
                time = 0;
                if (ran == 1)
                {
                    nvAgent.SetDestination(point1.transform.position);

                }
                else if (ran == 2)
                {
                    nvAgent.SetDestination(point2.transform.position);

                }
                else if (ran == 3)
                {
                    nvAgent.SetDestination(point3.transform.position);

                }
                else if (ran == 4)
                {
                    nvAgent.SetDestination(point4.transform.position);

                }
            }
           
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


        }


    }

}
