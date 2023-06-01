using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WorkerAnimation : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Transform[] _points;
    private Rigidbody _rb;
    [SerializeField] private WorkerMove _move;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        
        _anim.SetTrigger("onWalk");
    }

    private void Update()
    {
       

        if (transform.position == _points[3].position)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position == _points[0].position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // if (_move.OnRight == false)
        // {
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        //     
        // }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
        transform.DORotate(new Vector3(0, 90, 0), 0.7f);
            Debug.Log("dsd");
            _anim.SetTrigger("onStop");
            
        }
        
       
            
            
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            transform.DORotate(new Vector3(0, 180, 0), 0.3f, RotateMode.Fast);
        }
       
            
    }
    
}
