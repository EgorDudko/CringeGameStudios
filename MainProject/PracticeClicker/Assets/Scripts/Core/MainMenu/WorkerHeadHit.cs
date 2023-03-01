using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerHeadHit : MonoBehaviour
{
    [SerializeField] private MenuWorkerScript _worker;
    [SerializeField] private Animator _animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>())
            if (_worker.Anger) _animator.SetTrigger("Angry");
    }
}
