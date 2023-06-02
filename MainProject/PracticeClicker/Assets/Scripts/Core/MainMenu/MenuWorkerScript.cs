using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWorkerScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isMoveable = true;

    private bool _isAngry;
    private bool _isUnconscious;


    void Update()
    {
        if(_isMoveable) transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    public bool Anger
    {
        get => _isAngry;
    }

    private void AngerTrue()
    {
        _isAngry = true;
    }

    private void AngerFalse()
    {
        _isAngry = false;
    }
}
