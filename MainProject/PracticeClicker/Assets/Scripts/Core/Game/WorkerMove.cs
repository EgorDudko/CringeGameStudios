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
   private Animator _anim;
   private bool onRight;
   private int _n3;
   public int N3 => _n3;
   private int _n1;
   public int N1 => _n1;
   public bool OnRight => onRight;
   
 


    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (gameObject.layer == 10)
        {
            //transform.position = _startPos[0].position;
            onRight = true;
            StartCoroutine(FirstDirection());
            
        }
        if (gameObject.layer == 11)
        {
            transform.position = _startPos[1].position;
            onRight = true;
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
        if (transform.position == _startPos[0].position)
        {
            onRight = true;
        }
        else if (transform.position == _endPoints[0].position)
        {
            onRight = false;
        }

        _n1 = Random.Range(0, 2);
      while (transform.position != _stopPoints[0].transform.position && transform.position != _startPos[0].transform.position) 
      {
          if (transform.position != _startPos[0].position)
          {


              if (_n1 == 0)
              {

                  transform.position =
                      Vector3.MoveTowards(transform.position, _stopPoints[0].position, _speed * Time.deltaTime);
                  yield return new WaitForSeconds(Time.deltaTime);

              }
              else
              {
                  transform.position =
                      Vector3.MoveTowards(transform.position, _startPos[0].position, _speed * Time.deltaTime);
                  yield return new WaitForSeconds(Time.deltaTime);

              }

          }
          else
          {
              transform.position =
                  Vector3.MoveTowards(transform.position, _stopPoints[0].position, _speed * Time.deltaTime);
              yield return new WaitForSeconds(Time.deltaTime);
              
              
          }


      }
        
         yield return new WaitForSeconds(2.5f);
             
            
         while (transform.position != _endPoints[0].position )
         {
            
            
                onRight = true;
                
               transform.position =
                  Vector3.MoveTowards(transform.position, _endPoints[0].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
               
            
            
         } 


        
            
         yield return new WaitForSeconds(Random.Range(2, 5));
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
        
        yield return new WaitForSeconds(Random.Range(2,7));
        
        int n = Random.Range(0, 1);

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

        yield return new WaitForSeconds(Random.Range(3,7));
            StartCoroutine(SecondDirection());
        
       
    }

    private IEnumerator ThirdDirection()
   {
       _n3 = Random.Range(0, 2);
       while (transform.position != _stopPoints[2].transform.position && transform.position != _stopPoints[3].transform.position) 
       {
           if (_n3  == 0)
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

        yield return new WaitForSeconds(Random.Range(2,7));
        
        while (transform.position != _endPoints[2].position && transform.position != _startPos[2].position)
        {
            if (_n3 == 0)
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
