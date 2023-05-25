using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private int _boxLayer;
    [SerializeField] private int _maxBoxCount;
    [SerializeField] private Transform _outsidePosition;
    [SerializeField] private Transform _insidePosition;

    private int _boxCount;
    private bool _isMoving;

    void Start()
    {
        _isMoving = false;
        _boxCount = 0;
    }

    private IEnumerator SendTruck()
    {
        _isMoving = true;
        float t = 0;
        while (transform.position.x > _outsidePosition.position.x + 0.4f)
        {
            t += Time.deltaTime/10;
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0,0, 90), 0.01f);
            transform.position = Vector3.Lerp(transform.position, _outsidePosition.position, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, t)));
            yield return new WaitForFixedUpdate();
        }
        _boxCount = 0;
        t = 0;
        while (transform.position.x < _insidePosition.position.x - 0.4f)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, 0), 0.01f);
            transform.position = Vector3.Lerp(transform.position, _insidePosition.position, 0.02f);
            yield return new WaitForFixedUpdate();
        }
        while (_door.rotation.eulerAngles.z > 1)
        {
            _door.rotation = Quaternion.Lerp(_door.rotation, Quaternion.Euler(0, 0, 0), 0.01f);
            yield return new WaitForFixedUpdate();
        }
        _isMoving = false;
    }
    public void UpgradeCapacity()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _boxLayer)
        {
            other.transform.parent = transform;
            _boxCount++;
            if(!_isMoving && _maxBoxCount < _boxCount)
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
