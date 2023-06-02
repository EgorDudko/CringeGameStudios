using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoxEater : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoxCollider>())
        {
            if (other.transform.parent != null && other.transform.parent.GetComponent<MenuWorkerScript>())
            {
                Destroy(other.transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }

        }
    }
}
