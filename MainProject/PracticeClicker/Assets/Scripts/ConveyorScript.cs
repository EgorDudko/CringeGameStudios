using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Vector3 _position = other.transform.position;
            other.transform.position = new Vector3(_position.x + _speed* Time.deltaTime, _position.y, _position.z);
        }
    }
}
