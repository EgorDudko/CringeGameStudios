using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WorkerMove : MonoBehaviour
{
   [SerializeField] private Transform[] _startPos;
   [SerializeField] private Transform[] _stopPoints;
   [SerializeField] private Transform[] _endPoints;
   [SerializeField] private float _speed = 2;
   [SerializeField] private GameObject _prevWorker;
   [SerializeField] private GameObject _nextWorker;

    private int _n;


    private void Start()
    {
        transform.position = _startPos[0].position;
      
        StartCoroutine(FirstDirection());
    }

    private IEnumerator FirstDirection()
    {
      while (transform.position != _stopPoints[0].transform.position)
      {
         transform.position =
            Vector3.MoveTowards(transform.position, _stopPoints[0].position, _speed * Time.deltaTime);
         yield return new WaitForSeconds(Time.deltaTime);
      }

         yield return new WaitForSeconds(2);
            int n = Random.Range(0, 2);
         while (transform.position != _endPoints[0].position && transform.position != _startPos[0].position )
         {
            if (n == 0)
            {
               transform.position =
                  Vector3.MoveTowards(transform.position, _endPoints[0].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
               
            }
            else
            {
               transform.position =
                  Vector3.MoveTowards(transform.position, _startPos[0].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
               
            }
         }


        _prevWorker.SetActive(true);
        transform.position = _startPos[1].position;
        if (_nextWorker.transform.position == _startPos[2].position || _nextWorker.transform.position == _endPoints[1].position || _nextWorker.transform.position != _stopPoints[1].position)
            StartCoroutine(SecondDirection());
    }
   
   private IEnumerator SecondDirection()
   {
        while (transform.position != _stopPoints[1].transform.position)
        {
            transform.position =
               Vector3.MoveTowards(transform.position, _stopPoints[1].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(2);
        int n = Random.Range(0, 2);

        while (transform.position != _endPoints[1].position && transform.position != _startPos[1].position)
        {
            if (n == 0)
            {
                transform.position =
                   Vector3.MoveTowards(transform.position, _endPoints[1].position, _speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);

            }
            else
            {
                transform.position =
                   Vector3.MoveTowards(transform.position, _startPos[1].position, _speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);

            }
        }

        transform.position = _startPos[2].position;
        if (_nextWorker.transform.position == _startPos[0].position || _nextWorker.transform.position == _endPoints[2].position || _nextWorker.transform.position != _stopPoints[2].position)
            StartCoroutine(ThirdDirection());
    }

    private IEnumerator ThirdDirection()
   {
        while (transform.position != _stopPoints[2].transform.position)
        {
            transform.position =
               Vector3.MoveTowards(transform.position, _stopPoints[2].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(2);
        int n = Random.Range(0, 2);
        while (transform.position != _endPoints[2].position && transform.position != _startPos[2].position)
        {
            if (n == 0)
            {
                transform.position =
                   Vector3.MoveTowards(transform.position, _endPoints[2].position, _speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);

            }
            else
            {
                transform.position =
                   Vector3.MoveTowards(transform.position, _startPos[2].position, _speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);

            }
        }

        transform.position = _startPos[0].position;
        if (_nextWorker.transform.position == _startPos[1].position || _nextWorker.transform.position == _endPoints[0].position || _nextWorker.transform.position != _stopPoints[0].position)
            StartCoroutine(FirstDirection());
    }
}
