
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Worker2Animation : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private WorkerMove _move;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

   
    private void Update()
    {
        if (transform.position != _points[0].position && transform.position != _points[1].position &&
            transform.position != _points[2].position && transform.position != _points[3].position)
        {
            _anim.SetTrigger("onWalk");
        }
        else
        {
            _anim.SetTrigger("onIdle");
        }

        if (transform.position == _points[3].position)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position == _points[0].position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.layer == 15)
        {
            _anim.SetTrigger("onIdle");
            transform.DORotate(new Vector3(0, -90, 0), 0.5f);
            
        }
        if (other.gameObject.layer == 14)
        {
                _anim.SetTrigger("onIdle");
                transform.DORotate(new Vector3(0, 90, 0), 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
      
        if (other.gameObject.layer == 15)
        {
            transform.DORotate(new Vector3(0, -180, 0), 0.4f);
        }
        if (other.gameObject.layer == 14)
        {
            if (_move.N3 == 0)
            {
                _anim.SetTrigger("onIdle");
                transform.DORotate(new Vector3(0, 0, 0), 0.3f);
            }
            else
            {
                _anim.SetTrigger("onIdle");
                transform.DORotate(new Vector3(0, 180, 0), 0.3f);
            } 
        }
    }
}
