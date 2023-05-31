using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetectorScript : MonoBehaviour
{
    public bool _isCooldown;
    private int _itemsInTrigger;

    private void Start()
    {
        _isCooldown = false;
        _itemsInTrigger = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            _isCooldown = true;
            _itemsInTrigger++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _itemsInTrigger--;
            if (_itemsInTrigger == 0)
            {
                _isCooldown = false;
            }
        }
    }
}
