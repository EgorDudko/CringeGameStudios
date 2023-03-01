using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [SerializeField] private Storage _storage;

    private Rigidbody rb;

    private void OnTriggerStay(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = true;
            rb.velocity = transform.right * _storage.conveyorSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = false;
        }
    }
}
