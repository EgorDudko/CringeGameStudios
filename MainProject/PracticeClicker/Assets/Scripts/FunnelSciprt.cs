using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelSciprt : MonoBehaviour
{
    [SerializeField] GameObject _box;
    [SerializeField] GameObject _boxSpawner;
    private int cooldown = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Destroy(other.gameObject);
            Instantiate(_box, _boxSpawner.transform.position, _boxSpawner.transform.rotation);
            new WaitForSeconds(cooldown);
        }
    }
}
