using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour {
    public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;

    void Start()
    {
        Cursor.visible = false;
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        // move the camera position
        transform.position = target.transform.position + new Vector3(0,1,0) - (transform.forward * targetDistance);
    }
}