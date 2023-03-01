using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWorkerScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject[] _colliders;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private bool _isAngry;
    private bool _isUnconscious;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        foreach (GameObject i in _colliders)
        {
            Physics.IgnoreCollision(_rigidbody.GetComponent<Collider>(), i.GetComponent<Collider>());
        }
    }

    void Update()
    {
        _rigidbody.velocity = transform.forward * _moveSpeed;
        Debug.DrawRay(transform.position,_rigidbody.velocity*100, Color.green);
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
