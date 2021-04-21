using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ridgid boddy

    public Rigidbody rb;

    // forward force speed
    public float forwardForce = 0f;

    //side force speed
    public float sideForce = 0f;

    // Update is called once per frame
    float screenCenterX = Screen.width * 0.5f;
    private bool forward = false;
    public GameObject tap;
    
    void Update()
    {
        
        // forward force that pushed the cube
        if (Input.touchCount > 0 || Input.GetKey("p"))
        {
            tap.SetActive(false);
            forward = true;
            

        }
        if (forward)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
           
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > screenCenterX)
            {
                rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (touch.position.x < screenCenterX)
            {
                rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        if ( Input.GetKey("d"))
        {
            
            rb.AddForce(sideForce * Time.deltaTime, 0, 0 ,ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }

        if(rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public bool setForwardF (bool forward)
    {
        
       return this.forward = forward; 
    }
}
