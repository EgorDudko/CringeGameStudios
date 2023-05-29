using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _itemsSpawn;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject _itemButtonPrefab;
    [SerializeField] private GameObject _BuffSpawn1;
    [SerializeField] private GameObject _BuffSpawn2;
    [SerializeField] private GameObject _BuffSpawn3;
    [SerializeField] private Storage _storage;
    [SerializeField] private ItemDetectorCoolDown _itemDetectorCoolDown;
    [SerializeField] private Transform _spawnItemList;
    [SerializeField] private GameObject _unloadingPanel;
    [SerializeField] private string[] _addresses;

    private bool _buffIsWorking;
    private bool _isSpawning;
    private GameObject _spawningItemUI;
    private GameObject _spawningItemPrefab;

    void Start()
    {
        while (_spawnItemList.childCount > 10)
        {
            AddItemToList();
        }
        _isSpawning = false;
    }

    void Update()
    {
        if (_isSpawning && !_itemDetectorCoolDown._isClickCooldown)
        {
            Instantiate(_spawningItemPrefab, _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
            Destroy(_spawningItemUI);
            _isSpawning = false;
            _unloadingPanel.SetActive(false);
        }
        if (_spawnItemList.childCount < 10)
        {
            AddItemToList();
        }
    }

    private void AddItemToList()
    {
        Transform button = Instantiate(_itemButtonPrefab).transform;
        GameObject item = _items[Random.Range(0, _items.Length)];
        button.Find("Name").GetComponent<TMP_Text>().text = item.name;
        button.Find("Number").GetComponent<TMP_Text>().text = Random.Range(0, 999999999).ToString();
        button.Find("Address").GetComponent<TMP_Text>().text = "<u>Address</u>\n\n"+_addresses[Random.Range(0, _addresses.Length)];
        button.SetParent(_spawnItemList.transform, false);
        button.SetAsLastSibling();
        button.GetComponent<Button>().onClick.AddListener(() => SpawnItem(item, button.GetSiblingIndex()));
    }

    private void SpawnItem(GameObject item, int buttonIndex)
    {
        if (!_isSpawning)
        {
            _unloadingPanel.SetActive(true);
            _spawningItemPrefab = item;
            _spawningItemUI = _spawnItemList.GetChild(buttonIndex).gameObject;
            _isSpawning = true;
        }       
    }

    IEnumerator BuffCoroutine()
    {
        _buffIsWorking = true;
        float conveyorSpeed = _storage.conveyorSpeed;
        _storage.conveyorSpeed *= 5;
        _storage.boxSpawnCoolDown /= 5;
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn1.transform.position, _BuffSpawn1.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn2.transform.position, _BuffSpawn2.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn3.transform.position, _BuffSpawn3.transform.rotation);
        }
        yield return new WaitForSeconds(12);
        _storage.conveyorSpeed = conveyorSpeed;
        _buffIsWorking = false;
    }
}
