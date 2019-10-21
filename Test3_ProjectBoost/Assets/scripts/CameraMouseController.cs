using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseController : MonoBehaviour
{
    public Transform target;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        yaw += speedH * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= speedV * Input.GetAxis("Mouse Y") * Time.deltaTime;

        transform.eulerAngles = new Vector3(pitch, yaw , 0.0f);
        
    }
}
