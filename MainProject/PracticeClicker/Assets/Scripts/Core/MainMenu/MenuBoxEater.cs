using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoxEater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoxCollider>())
        {
            Destroy(other.gameObject);
        }
    }
}
