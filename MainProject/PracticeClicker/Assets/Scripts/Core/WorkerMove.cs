using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WorkerMove : MonoBehaviour
{
   
 

   [SerializeField] private Transform[] startPos;
   [SerializeField] private Transform[] stopPoints;
   [SerializeField] private Transform[] endPoints;
   [SerializeField] private float _speed = 2;
   private int _n;
   [SerializeField] private GameObject prevWorker;
   [SerializeField] private GameObject nextWorker;
  

   private void Start()
   {
      transform.position = startPos[0].position;
      
     StartCoroutine(FirstDirection());

   }

   private void Update()
   {
      
   }

    IEnumerator FirstDirection()
   {
      while (transform.position != stopPoints[0].transform.position)
      {
         transform.position =
            Vector3.MoveTowards(transform.position, stopPoints[0].position, _speed * Time.deltaTime);
         yield return new WaitForSeconds(Time.deltaTime);
      }

         yield return new WaitForSeconds(2);
            int n = Random.Range(0, 2);
         while (transform.position != endPoints[0].position && transform.position != startPos[0].position )
         {
            if (n == 0)
            {
               transform.position =
                  Vector3.MoveTowards(transform.position, endPoints[0].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
               
            }
            else
            {
               transform.position =
                  Vector3.MoveTowards(transform.position, startPos[0].position, _speed * Time.deltaTime);
               yield return new WaitForSeconds(Time.deltaTime);
               
            }
         }

         
            prevWorker.SetActive(true);
            transform.position = startPos[1].position;
            if(nextWorker.transform.position == startPos[2].position || nextWorker.transform.position == endPoints[1].position || nextWorker.transform.position != stopPoints[1].position )
            StartCoroutine(SecondDirection());



         

        
   }
   
   IEnumerator SecondDirection()
   {
      while (transform.position != stopPoints[1].transform.position)
      {
         transform.position =
            Vector3.MoveTowards(transform.position, stopPoints[1].position, _speed * Time.deltaTime);
         yield return new WaitForSeconds(Time.deltaTime);
      }

      yield return new WaitForSeconds(2);
      int n = Random.Range(0, 2);
      while (transform.position != endPoints[1].position && transform.position != startPos[1].position )
      {
         if (n == 0)
         {
            transform.position =
               Vector3.MoveTowards(transform.position, endPoints[1].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
               
         }
         else
         {
            transform.position =
               Vector3.MoveTowards(transform.position, startPos[1].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
               
         }
      }
     
         transform.position = startPos[2].position;
         if(nextWorker.transform.position == startPos[0].position || nextWorker.transform.position == endPoints[2].position || nextWorker.transform.position != stopPoints[2].position )
         StartCoroutine(ThirdDirection());
         



      

     
      
   }
  IEnumerator ThirdDirection()
   {
      while (transform.position != stopPoints[2].transform.position)
      {
         transform.position =
            Vector3.MoveTowards(transform.position, stopPoints[2].position, _speed * Time.deltaTime);
         yield return new WaitForSeconds(Time.deltaTime);
      }

      yield return new WaitForSeconds(2);
      int n = Random.Range(0, 2);
      while (transform.position != endPoints[2].position && transform.position != startPos[2].position )
      {
         if (n == 0)
         {
            transform.position =
               Vector3.MoveTowards(transform.position, endPoints[2].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
               
         }
         else
         {
            transform.position =
               Vector3.MoveTowards(transform.position, startPos[2].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
               
         }
      }
      
         transform.position = startPos[0].position;
         if(nextWorker.transform.position == startPos[1].position || nextWorker.transform.position == endPoints[0].position || nextWorker.transform.position != stopPoints[0].position)
         StartCoroutine(FirstDirection());
         



      
      
   
     
      
   }
}
