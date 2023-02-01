using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelSciprt : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _boxSpawner;
    [SerializeField] private int _spawnCooldown;
    
    private bool _isSpawnCooldown;

    private void OnTriggerStay(Collider other)
    {
        if (!_isSpawnCooldown && other.GetComponent<Rigidbody>())
        {
            Destroy(other.gameObject);
            Instantiate(_box, _boxSpawner.transform.position, _boxSpawner.transform.rotation);
            StartCoroutine(SpawnCooldown());
        }
    }
    IEnumerator SpawnCooldown()
    {
        _isSpawnCooldown = true;
        yield return new WaitForSeconds(_spawnCooldown);
        _isSpawnCooldown = false;
    }
}
