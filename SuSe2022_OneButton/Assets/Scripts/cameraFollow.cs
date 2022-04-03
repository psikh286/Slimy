using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //public vars
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        Camera();
    }
    
    private void Camera()
    {
        //vars
        Vector3 desired_position = target.position;
        Vector3 smoothed_position = Vector3.Lerp(transform.position, desired_position + offset, smoothSpeed * Time.deltaTime);

        //sets the position
        transform.position = smoothed_position;        
    }
}
