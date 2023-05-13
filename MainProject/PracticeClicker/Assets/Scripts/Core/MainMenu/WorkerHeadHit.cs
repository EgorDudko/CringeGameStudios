using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerHeadHit : MonoBehaviour
{
    [SerializeField] private MenuWorkerScript _worker;
    [SerializeField] private Animator _animator;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BoxCollider>())
        {
            if(!_worker.Anger)_animator.SetTrigger("Angry");
            collision.collider.GetComponent<Rigidbody>().velocity = (collision.collider.transform.position - transform.position)*5;
        }
    }
}
