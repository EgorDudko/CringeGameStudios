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
    [SerializeField] private float _minTimeBuffApear = 60;
    [SerializeField] private float _maxTimeBuffApear = 120;
    [SerializeField] private float _maxTimeBuffDisapear = 15;
    [SerializeField] private GameObject _BuffSpawn1;
    [SerializeField] private GameObject _BuffSpawn2;
    [SerializeField] private GameObject _BuffSpawn3;
    [SerializeField] private Storage _storage;
    [SerializeField] private ItemDetectorCoolDown _itemDetectorCoolDown;
    [SerializeField] private Transform _spawnItemList;
    [SerializeField] private GameObject _buffPanel;
    [SerializeField] private TMP_Text _buffTimeText;
    [SerializeField] private Button _buffButton;
    [SerializeField] private GameObject _unloadingPanel;
    [SerializeField] private GameObject _unloadingPanelUpgrades;
    [SerializeField] private string[] _addresses;

    private bool _buffIsWorking;
    private float _timeForNextBuff;
    private bool _isSpawning;
    private GameObject _spawningItemPrefab;

    void Start()
    {
        _timeForNextBuff = Random.Range(_minTimeBuffApear, _maxTimeBuffApear);
        while (_spawnItemList.childCount > 10)
        {
            AddItemToList();
        }
        _isSpawning = false;
        _buffIsWorking = false;
        _buffButton.onClick.AddListener(LaunchBuff);
    }

    void Update()
    {
        _timeForNextBuff -= Time.deltaTime;

        if (_isSpawning && !_itemDetectorCoolDown._isClickCooldown)
        {
            Instantiate(_spawningItemPrefab, _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
            _isSpawning = false;
            _unloadingPanel.SetActive(false);
        }
        if (_spawnItemList.childCount < 10)
        {
            AddItemToList();
        }

        if(_timeForNextBuff <= 0)
        {
            StartCoroutine(BuffPanelCoroutine());
            _timeForNextBuff = Random.Range(_minTimeBuffApear, _maxTimeBuffApear);
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
            Destroy(_spawnItemList.GetChild(buttonIndex).gameObject);
            _unloadingPanel.SetActive(true);
            _spawningItemPrefab = item;
            _isSpawning = true;
        }       
    }

    public void SpawnItem()
    {
        GameObject item = _items[Random.Range(0, _items.Length)];
        Instantiate(item, _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
    }

    public void LaunchBuff()
    {
        _buffPanel.SetActive(false);
        StartCoroutine(BuffCoroutine());
    }

    private IEnumerator BuffPanelCoroutine()
    {
         float _appearedBuffTime = 0;
        _buffPanel.SetActive(true);
        _buffTimeText.text = (_maxTimeBuffDisapear - _appearedBuffTime).ToString() + "s";
        while (_appearedBuffTime < _maxTimeBuffDisapear)
        {
            yield return new WaitForSeconds(1);
            _appearedBuffTime += 1;
            _buffTimeText.text = (_maxTimeBuffDisapear - _appearedBuffTime).ToString()+"s";
        }
        _buffPanel.SetActive(false);
    }

    private IEnumerator BuffCoroutine()
    {
        _unloadingPanelUpgrades.SetActive(true);
        _buffIsWorking = true;
        float conveyorSpeed = _storage.conveyorSpeed;
        _storage.conveyorSpeed *= 5;
        _storage.boxSpawnCoolDown /= 5;
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn1.transform.position, _BuffSpawn1.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn2.transform.position, _BuffSpawn2.transform.rotation);
            Instantiate(_items[Random.Range(0, _items.Length)], _BuffSpawn3.transform.position, _BuffSpawn3.transform.rotation);
        }
        yield return new WaitForSeconds(5);
        _storage.conveyorSpeed = conveyorSpeed;
        _buffIsWorking = false;
        _unloadingPanelUpgrades.SetActive(false);
    }
}
