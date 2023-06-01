using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _workers;
    [SerializeField] private int[] _workerValue;
    [SerializeField] private ItemsSpawner _itemSpawner;
    [SerializeField] private TMP_Text[] _workersCosts;
    [SerializeField] private Storage _storage;
    [SerializeField] private AudioSource _buyAudioSource;

    private int _workersCount;

    void Start()
    {
        for (int i = 0; i < _workers.Length; i++)
        {
            _workersCosts[i].text = _workerValue[i].ToString() + "$";
        }

        StartCoroutine(AutoClicking());
    }

    public void SpawnWorker(int workerNumber)
    {
        if(_storage.Money >= _workerValue[workerNumber])
        {
            _workersCount++;
            _workers[workerNumber].SetActive(true);
            Button workerPanel = _workersCosts[workerNumber].transform.parent.GetComponent<Button>();
            workerPanel.interactable = false;
            _workersCosts[workerNumber].text = "Hired";
            _buyAudioSource.Play();
        }
    }

    private IEnumerator AutoClicking()
    {
        while (true)
        {
            if (_workersCount > 0) _itemSpawner.SpawnItem();
            yield return new WaitForSeconds(1/ (_workersCount ==0 ? 1 : (float)_workersCount));
        }
    }
}
