using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCleaning : MonoBehaviour
{
    [SerializeField] private float _cleaningTime = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6|| other.gameObject.layer == 7)
            StartCoroutine(ItemClean(other.gameObject));
    }

    IEnumerator ItemClean(GameObject trash)
    {
        yield return new WaitForSeconds(_cleaningTime);
        Destroy(trash);
    }
}
