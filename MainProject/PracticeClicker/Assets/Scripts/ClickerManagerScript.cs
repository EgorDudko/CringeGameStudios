using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject _itemsSpawn;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject _cooldownColoredIndicator;
    [SerializeField] private Material _redIndicator;
    [SerializeField] private Material _greenIndicator;
    [SerializeField] private float _clickCooldown;
    [SerializeField] private float _autoclickCheatDetector;

    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _isClickCooldown;
    private float _lastClickPastTime;

    void Start()
    {
        _lastClickPastTime = 100;
        _mainCamera = Camera.main;
    }

    void Update()
    {
        _lastClickPastTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (_lastClickPastTime <= _autoclickCheatDetector)
            {
                Debug.Log("AUTO-CLICK DETECTED!!!!!");
            }

            if (!_isClickCooldown)
            {
                _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit, 100))
                {
                    if (_hit.transform.tag == "ObjectForClick")
                    {
                        Instantiate(_items[Random.Range(0,_items.Length)], _itemsSpawn.transform.position, _itemsSpawn.transform.rotation);
                        StartCoroutine(ClickCooldown());
                    }
                }
            }

            _lastClickPastTime = 0f;
        }
    }

    IEnumerator ClickCooldown()
    {
        _isClickCooldown = true;
        _cooldownColoredIndicator.GetComponent<MeshRenderer>().material = _redIndicator;
        yield return new WaitForSeconds(_clickCooldown);
        _cooldownColoredIndicator.GetComponent<MeshRenderer>().material = _greenIndicator;
        _isClickCooldown = false;
    }
}
