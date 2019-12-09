using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.AI;

public class player : MonoBehaviour
{
    public Transform player1;
    NavMeshAgent agent;
    public Transform p1, p2, p3;
    int Index = 0;
    Animator fsm;
    Vector3[] wayPoints;
    GameObject engel;
    public Text text; 
    public GameObject muzikler;
    public GameObject gm;
    public GameObject sahneGecis;
    public Button button;


    void Start()
    {
        wayPoints = new Vector3[] { p1.position, p2.position, p3.position };
        fsm = GetComponent<Animator>();
        text.GetComponent<Text>().enabled=false;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[Index]);
        muzikler.GetComponent<muzik>().musicPlay();
        button.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceFromWayPoint = Vector3.Distance(transform.position, wayPoints[Index]);
        fsm.SetFloat("distanceFromWaypoint", distanceFromWayPoint);
    }

    public void Patrol()
    {

    }
    

    public void SetNextWayPoint()
    {
        switch (Index)
        {
            case 0:
                Index = 1;
                break;
            case 1:
                Index = 2;
                break;
            case 2:
                Index = 0;
                break;
        }

        agent.SetDestination(wayPoints[Index]);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("EngelTag"))
        {
            Camera.main.transform.SetParent(gm.transform);
            text.GetComponent<Text>().enabled = true;
            muzikler.GetComponent<muzik>().musicStop();
            button.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("KasirgaTag"))
        {
            Camera.main.transform.SetParent(gm.transform);
            text.GetComponent<Text>().enabled = true;
            muzikler.GetComponent<muzik>().musicStop();
            button.gameObject.SetActive(true);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().enabled = false;
        muzikler.GetComponent<muzik>().musicStop();
        text.GetComponent<Text>().enabled = true;
        text.text = "Loading Next Level...";
        sahneGecis.GetComponent<sonrakiSeviye>().oyunagit();
    }
}
