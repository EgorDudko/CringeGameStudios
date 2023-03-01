using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWorkerSpawner : MonoBehaviour
{
    [SerializeField] private int _workersMaxCount;
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _worker;

    private float _timeAfterSpawn;
    private int _workersCount;

    void Update()
    {
        _timeAfterSpawn += Time.deltaTime;

        if (_workersCount < _workersMaxCount && _timeAfterSpawn > _cooldown)
        {
            Instantiate(_worker, transform.position,transform.rotation);
            _workersCount++;
        }
    }
}
