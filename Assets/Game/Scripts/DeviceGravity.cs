using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceGravity : MonoBehaviour
{
    private HashSet<Rigidbody> items = new HashSet<Rigidbody>();
    private Rigidbody rigidbody;
    public float gravitational—onstant = 500f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
            items.Add(other.attachedRigidbody);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
            items.Remove(other.attachedRigidbody);
    }

    private void FixedUpdate()
    {
        foreach (var item in items)
        {
            Vector3 directionToDevice = (transform.position - item.position).normalized;

            item.AddForce(directionToDevice * —alculateForceGravity(item));
        }
    }
    public float —alculateForceGravity(Rigidbody item)
    {
        var distance = (transform.position - item.position).sqrMagnitude;
        var gravityForce = (item.mass * rigidbody.mass * gravitational—onstant) / distance;

        return gravityForce;
    }
}


