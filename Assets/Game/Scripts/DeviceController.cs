using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private FixedJoystick joystick;

    public float moveSpeed = 150f;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.deltaTime, 
            rigidbody.velocity.y, joystick.Vertical * moveSpeed * Time.deltaTime);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);  
        }
    }
}
