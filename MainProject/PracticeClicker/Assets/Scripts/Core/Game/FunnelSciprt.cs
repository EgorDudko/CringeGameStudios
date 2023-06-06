using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelSciprt : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _boxSpawner;
    [SerializeField] private BoxDetectorScript _boxDetector;
    [SerializeField] private Storage _storage;


    private void OnTriggerStay(Collider other)
    {
        if (!_boxDetector._isCooldown && other.GetComponent<Rigidbody>())
        {
            _boxDetector._isCooldown = true;
            Destroy(other.gameObject);
            Instantiate(_box, _boxSpawner.transform.position, _boxSpawner.transform.rotation);
        }
    }
}
