using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceGravity : MonoBehaviour
{
    private HashSet<Rigidbody> items = new HashSet<Rigidbody>();
    private Rigidbody rigidbody;
    [SerializeField]
    private float gravitational—onstant = 500f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            items.Add(other.attachedRigidbody);
        }
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
            item.AddForce(new Vector3(0, 5, 0) * —alculateForceGravity(item));
        }
    }
    public float —alculateForceGravity(Rigidbody item)
    {
        var distance = (transform.position - item.position).sqrMagnitude;
        var gravityForce = (item.mass * rigidbody.mass * gravitational—onstant) / distance;

        return gravityForce;
    }
}


