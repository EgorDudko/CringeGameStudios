using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour
{
    [SerializeField] private Storage _storage;

    private Rigidbody rb;
    private bool _isSpeeded;

    private void Start()
    {
        _isSpeeded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = true;
            if (_isSpeeded)
            {
                if(_storage.ValueLevel != _storage.SpeedUpgrades.Length - 1)
                    rb.velocity = transform.right * _storage.SpeedUpgrades[_storage.SpeedUpgrades.Length - 1];
                else
                    rb.velocity = transform.right * _storage.SpeedUpgrades[_storage.SpeedUpgrades.Length - 1]*1.2f;
            }
            else rb.velocity = transform.right * _storage.conveyorSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (rb = other.GetComponent<Rigidbody>())
        {
            rb.freezeRotation = false;
        }
    }

    public void SpeedUp(float time)
    {
        if (!_isSpeeded)
            StartCoroutine(SpeedUpCoroutine(time));
    }

    private IEnumerator SpeedUpCoroutine(float time)
    {
        _isSpeeded = true;
        yield return new WaitForSeconds(time);
        _isSpeeded = false;
    }
}
