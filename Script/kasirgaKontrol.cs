using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class kasirgaKontrol : MonoBehaviour
{
   
    public int Hiz=10000;
    Rigidbody rb; 
    float dikey, yatay;
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>(); ///fiziksel özellikleri alınmış
        gameObject.GetComponent<kasirgaKontrol>();
        m_Cam = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {

        float yatay = CrossPlatformInputManager.GetAxis("Horizontal");

        float dikey = CrossPlatformInputManager.GetAxis("Vertical");



        if (m_Cam != null)
        { 
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = dikey * m_CamForward + yatay * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = dikey * Vector3.forward + yatay * Vector3.right;
        }




        Vector3 hareket = m_Move * Hiz;
        rb.AddForce(hareket);
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody != null)
        collision.rigidbody.AddForce(collision.transform.position.x * 700f, collision.transform.position.x * 200f, collision.transform.position.z*700f);

    }
    
}


