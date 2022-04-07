using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    //public vars    
    public float smoothSpeed;
    public Vector3 offset;

    private Transform target;

	private void Start()
	{
        target = moveTowards.Instance.transform;
	}

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
