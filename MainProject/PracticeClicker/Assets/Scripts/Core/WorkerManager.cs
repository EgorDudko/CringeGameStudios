using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _workersPrefabs;
    [SerializeField] private Transform[] _workersPositions;
    [SerializeField] private ItemsSpawner _itemSpawner;

    private bool[] _areHired;

    void Start()
    {
        _areHired = new bool[_workersPrefabs.Length];
        for (int i = 0; i < _workersPrefabs.Length; i++)
        {
            _areHired[i] = false;
        }

        StartCoroutine(AutoClicking());
    }

    public void SpawnWorker(int workerNumber)
    {
        if (_areHired[workerNumber] == false)
        {
            _areHired[workerNumber] = true;
            Instantiate(_workersPrefabs[workerNumber], _workersPositions[workerNumber]);
        }
    }

    private IEnumerator AutoClicking()
    {
        while (true)
        {
            for (int i = 0; i < _workersPrefabs.Length; i++)
            {
                if (_areHired[i]) _itemSpawner.SpawnItem();
                yield return new WaitForSeconds(1);
            }
        }
    }
}
