using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelForce : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private void OnTriggerStay(Collider other)
    {
        if (_rigidbody = other.GetComponent<Rigidbody>())
        {
            _rigidbody.freezeRotation = true;
            _rigidbody.velocity = -transform.up * 2;
        }
    }
}
