using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetectorScript : MonoBehaviour
{
    public bool _isClickCooldownBox;
    private int _itemsInTrigger;

    private void Start()
    {
        _isClickCooldownBox = false;
        _itemsInTrigger = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isClickCooldownBox = true;
        _itemsInTrigger++;
    }
    private void OnTriggerExit(Collider other)
    {

        _itemsInTrigger--;
        if (_itemsInTrigger == 0)
        {
            _isClickCooldownBox = false;
        }
    }
}
