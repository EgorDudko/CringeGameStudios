using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxEatingScript : MonoBehaviour
{
    [SerializeField] private int _layer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            Destroy(other.gameObject);
        }
    }
}
