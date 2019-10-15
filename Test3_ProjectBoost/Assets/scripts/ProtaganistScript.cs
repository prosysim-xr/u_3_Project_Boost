using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtaganistScript : MonoBehaviour
{
    Rigidbody rigidbody; //getting rigid body object reference to use in our rocket script in our case -ProtaganistScript
    AudioSource audioSource;
    //float Xaxis;
    //float Yaxis;
    //float Zaxis;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessInput();
    }
    
    private void ProcessInput()
    {
        ThrustUp();
        RotateSideways();
        RotateForward();
    }
    private void ThrustUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }
    private void RotateSideways()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(-Vector3.right);//*Time.deltaTime);
            //transform.position += -Vector3.right * Time.deltaTime;
            transform.Rotate(0, 0, -30 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(Vector3.right);// * Time.deltaTime);
            //transform.Rotate += Vector3.right * Time.deltaTime;
            transform.Rotate( 0, 0, 30 * Time.deltaTime);
        }
    }
    private void RotateForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-30 * Time.deltaTime,0,0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(30 * Time.deltaTime, 0, 0);
        }
    }

    

    
}
