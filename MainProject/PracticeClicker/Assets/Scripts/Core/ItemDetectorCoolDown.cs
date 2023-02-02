using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetectorCoolDown : MonoBehaviour
{
    [SerializeField] private Material _redIndicator;
    [SerializeField] private Material _greenIndicator;
    [SerializeField] private GameObject _cooldownColoredIndicator;

    private static bool _isClickCooldown;
    private int _itemsInTrigger;

    private void Start()
    {
        _isClickCooldown = false;
        _itemsInTrigger = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _itemsInTrigger++;
        _isClickCooldown = true;
        _cooldownColoredIndicator.GetComponent<MeshRenderer>().material = _redIndicator;
    }
    private void OnTriggerExit(Collider other)
    {

        _itemsInTrigger--;
        if (_itemsInTrigger == 0)
        {
            _isClickCooldown = false;
            _cooldownColoredIndicator.GetComponent<MeshRenderer>().material = _greenIndicator;
        }
    }

    public static bool isCoolDown
    {
        get 
        {
            return _isClickCooldown;
        }
    }
}
