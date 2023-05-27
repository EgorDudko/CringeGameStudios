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
    [SerializeField] private int _boxLayer;
    [SerializeField] private Transform _outsidePosition;
    [SerializeField] private Transform _insidePosition;
    [SerializeField] private Storage _storage;

    private int _boxCount;
    private bool _isMoving;

    void Start()
    {
        _isMoving = false;
        _boxCount = 0;
        _capacityText.text = "0/"+ _storage.truckCapacity;
        _sendButton.onClick.AddListener(SendGoods);
        _blockingCollider.SetActive(false);
    }

    private IEnumerator SendTruck()
    {
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
        _boxCount = 0;
        _blockingCollider.SetActive(false);
        t = 0;
        while (transform.position.x < _insidePosition.position.x - 0.4f)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, 0), 0.01f);
            transform.position = Vector3.Lerp(transform.position, _insidePosition.position, 0.02f);
            yield return new WaitForFixedUpdate();
        }
        while (_door.rotation.eulerAngles.z > 1)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, 0), 0.06f);
            yield return new WaitForFixedUpdate();
        }
        _isMoving = false;
    }

    private void SendGoods()
    {
        if (!_isMoving)
        {
            StartCoroutine(SendTruck());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _boxLayer)
        {
            other.transform.parent = transform;
            if(_storage.truckCapacity >= _boxCount) _capacityText.text = (_boxCount++) + "/" + _storage.truckCapacity;
            if(!_isMoving && _storage.truckCapacity < _boxCount)
            {
                StartCoroutine(SendTruck());
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
