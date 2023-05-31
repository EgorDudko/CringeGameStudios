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
   
 


    private void Start()
    {
        if (gameObject.layer == 10)
        {
            transform.position = _startPos[0].position;
          
            StartCoroutine(FirstDirection());
            
        }
        if (gameObject.layer == 11)
        {
            transform.position = _startPos[1].position;
          
            StartCoroutine(SecondDirection());
            
        }
        if (gameObject.layer == 12)
        {
            transform.position = _startPos[2].position;
          
            StartCoroutine(ThirdDirection());
            
        }
    }

    private IEnumerator FirstDirection()
    {
        int _n = Random.Range(0, 1);
      while (transform.position != _stopPoints[0].transform.position && transform.position != _stopPoints[3].transform.position) 
      {
          if (_n == 0)
          {
             transform.position =
                Vector3.MoveTowards(transform.position, _stopPoints[0].position, _speed * Time.deltaTime);
             yield return new WaitForSeconds(Time.deltaTime);
              
          }
          else
          {
              transform.position =
                  Vector3.MoveTowards(transform.position, _stopPoints[3].position, _speed * Time.deltaTime);
              yield return new WaitForSeconds(Time.deltaTime);
              
          }
      }

         yield return new WaitForSeconds(Random.Range(1,4));
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


        
            
         yield return new WaitForSeconds(Random.Range(0,2));
            StartCoroutine(FirstDirection());
        
        
    }
   
   private IEnumerator SecondDirection()
   {
       int _n = Random.Range(0, 1);
       while (transform.position != _stopPoints[1].transform.position && transform.position != _stopPoints[3].transform.position) 
       {
           if (_n == 0)
           {
               transform.position =
                   Vector3.MoveTowards(transform.position, _stopPoints[1].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
              
           }
           else
           {
               transform.position =
                   Vector3.MoveTowards(transform.position, _stopPoints[3].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
              
           }
       }

        yield return new WaitForSeconds(Random.Range(1,4));
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

        yield return new WaitForSeconds(Random.Range(0,2));
            StartCoroutine(SecondDirection());
        
       
    }

    private IEnumerator ThirdDirection()
   {
       int _n = Random.Range(0, 1);
       while (transform.position != _stopPoints[2].transform.position && transform.position != _stopPoints[3].transform.position) 
       {
           if (_n == 0)
           {
               transform.position =
                   Vector3.MoveTowards(transform.position, _stopPoints[2].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
              
           }
           else
           {
               transform.position =
                   Vector3.MoveTowards(transform.position, _stopPoints[3].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
              
           }
       }

        yield return new WaitForSeconds(Random.Range(1,4));
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

        yield return new WaitForSeconds(Random.Range(0,2));
            StartCoroutine(ThirdDirection());
        
    }
}
