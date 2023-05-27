using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetectorCoolDown : MonoBehaviour
{
    [SerializeField] private Material _redIndicator;
    [SerializeField] private Material _greenIndicator;
    [SerializeField] private GameObject _cooldownColoredIndicator;

    public bool _isClickCooldown;
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
    }
    private void OnTriggerExit(Collider other)
    {

        _itemsInTrigger--;
        if (_itemsInTrigger == 0)
        {
            _isClickCooldown = false;
        }
    }
}
