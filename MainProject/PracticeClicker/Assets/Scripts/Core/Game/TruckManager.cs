using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TruckManager : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Button _sendButton;
    [SerializeField] private GameObject _blockingCollider;
    [SerializeField] private TMP_Text _capacityText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private string _changeMoneyText;
    [SerializeField] private int _boxLayer;
    [SerializeField] private Transform _outsidePosition;
    [SerializeField] private Transform _insidePosition;
    [SerializeField] private Storage _storage;
    [SerializeField] private AudioSource _clickAudioSource;
    [SerializeField] private AudioSource _truckAudioSource;
    [SerializeField] private AudioSource _cashAudioSource;

    private int _boxCount;
    private bool _isMoving;
    private Coroutine _cosingDoor;
    private List<GameObject> _boxes;

    void Start()
    {
        _boxes = new List<GameObject>();
        _isMoving = false;
        _boxCount = 0;
        _storage.truckCapacity = _storage.truckCapacityUpgrades[_storage.truckCapacityLevel];
        _capacityText.text = "0/"+ _storage.truckCapacity;
        _sendButton.onClick.AddListener(SendGoods);
        _blockingCollider.SetActive(false);
    }

    private IEnumerator SendTruck()
    {
        _truckAudioSource.Play();
        if (_cosingDoor != null)
        {
            StopCoroutine(_cosingDoor);
            _cosingDoor = null;
        }

        _isMoving = true;
        _blockingCollider.SetActive(true);
        float t = 0;
        while (transform.position.x > _outsidePosition.position.x + 0.4f)
        {
            t += Time.deltaTime/10;
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0,0, 90), 0.01f);
            transform.position = Vector3.Lerp(transform.position, _outsidePosition.position, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, t)));
            yield return new WaitForFixedUpdate();
        }
        _capacityText.text = "0/" + _storage.truckCapacity;
        if (_boxCount > 0) 
        { 
            _cashAudioSource.Play();
            _storage.money += _boxCount *_storage.itemsValue;
            _moneyText.text = _changeMoneyText + _storage.money + "$";
        }
        _boxCount = 0;
        _blockingCollider.SetActive(false);
        t = 0;
        _boxes = new List<GameObject>();
        if (_cosingDoor != null)
        {
            StopCoroutine(_cosingDoor);
            _cosingDoor = null;
        }
        while (transform.position.x < _insidePosition.position.x - 0.4f)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, -14), 0.01f);
            transform.position = Vector3.Lerp(transform.position, _insidePosition.position, 0.06f);
            yield return new WaitForFixedUpdate();
        }
        while (!(_door.rotation.eulerAngles.z < 350 && _door.rotation.eulerAngles.z > 300))
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, -14), 0.06f);
            yield return new WaitForFixedUpdate();
        }
        _truckAudioSource.Stop();
        _isMoving = false;
    }
    private IEnumerator CloseDoor()
    {
        while ((_door.rotation.eulerAngles.z < 360 && _door.rotation.eulerAngles.z > 300) || _door.rotation.eulerAngles.z < 90)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, 90), 0.01f);
            yield return new WaitForFixedUpdate();
        }

    }

    private void SendGoods()
    {
        if (!_isMoving)
        {
            StartCoroutine(SendTruck());
            _clickAudioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _boxLayer && !_boxes.Contains(other.gameObject))
        {
            _boxes.Add(other.gameObject);
            other.transform.parent = transform;
            _boxCount++;
            if (_storage.truckCapacity >= _boxCount) _capacityText.text = _boxCount + "/" + _storage.truckCapacity;

            if(_cosingDoor == null && _storage.truckCapacity < _boxCount)
            {
                _cosingDoor = StartCoroutine(CloseDoor());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _boxLayer)
        {
            other.transform.parent = transform;
        }
    }
}
