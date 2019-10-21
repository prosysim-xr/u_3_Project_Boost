using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtaganistScript : MonoBehaviour
{
    //todo: may be fix lighting issue

    //<Game states>
    [SerializeField] float rcsMainThrust;   //r eaction control system
    [SerializeField] float rcsFrontwaysThrust;
    [SerializeField] float rcsSidewaysThrust;

    enum State{Alive, Dying, Transcending}
    State state = State.Alive;

    Rigidbody rigidbody; //getting rigid body object reference to use in our rocket script in our case -ProtaganistScript
    AudioSource audioSource;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(state == State.Alive)
        {
            ProcessInput();
        }
        
    }
    
    private void ProcessInput()
    {
        ThrustUp();
        RotateSideways();
        RotateForward();
        
    }
    private void ThrustUp()
    {
        var translationFrame = rcsMainThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * translationFrame);
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
        rigidbody.freezeRotation = true;    //stops the physics control of the game
        var rotationFrame = rcsSidewaysThrust * Time.deltaTime;
        //float rcsSidewaysThrust;

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += -Vector3.right * Time.deltaTime;
            transform.Rotate(0, 0, -rotationFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(Vector3.right);// * Time.deltaTime);
            transform.Rotate(0, 0, rotationFrame);
        }

        rigidbody.freezeRotation = false;   //resumes the physics
    }
    private void RotateForward()
    {
        rigidbody.freezeRotation = true;
        var rotationFrame = rcsFrontwaysThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-rotationFrame, 0,0);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(rotationFrame, 0, 0);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) {return;} // so that no collision switch executed if not State.Alive

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    //do nothing
                    break;
                }
            case "Enemy":
                {
                    state = State.Dying;
                    SceneManager.LoadScene(0);
                    break;
                }
            case "Finish":
                {
                    state = State.Transcending;
                    Invoke("LoadNextlevel", 1f);    //paramatrized time to call the function  after a delay of 1 second
                    break;
                }
            default:    //Enemy tag also included actuly in this
                {
                    state = State.Dying;
                    SceneManager.LoadScene(0);
                    break;
                }
        }
    }

    private static void LoadNextlevel()
    {
        SceneManager.LoadScene(1);//todo more level accomodate.
    }
}
