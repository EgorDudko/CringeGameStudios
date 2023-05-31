using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorkerMovement : MonoBehaviour
{
   [SerializeField] private GameObject[] Workers;
 

   [SerializeField] private Transform[] startPos;
   [SerializeField] private Transform[] stopPoints;
   [SerializeField] private Transform[] endPoints;
   [SerializeField] private float _speed = 2;
   private int _n;
  

   private void Start()
   {
      Workers[0].transform.position = startPos[0].position;
      Workers[1].transform.position = startPos[1].position;
      Workers[2].transform.position = startPos[2].position;
     StartCoroutine(FirstDirection());

   }

   private void Update()
   {
      
   }

   public IEnumerator FirstDirection()
   {
      while (Workers[0].transform.position != stopPoints[0].transform.position)
      {
         Workers[0].transform.position =
            Vector3.MoveTowards(Workers[0].transform.position, stopPoints[0].position, _speed * Time.deltaTime);
         yield return new WaitForSeconds(Time.deltaTime);
      }

         yield return new WaitForSeconds(Random.Range(1, 3));
         while (Workers[0].transform.position != endPoints[0].position)
         {

            Workers[0].transform.position =
               Vector3.MoveTowards(Workers[0].transform.position, endPoints[0].position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
         }

         if (Workers[0].transform.position == endPoints[0].position)
            {
               
              
               Workers[1].transform.position = startPos[0].position;
               Workers[0].transform.position = startPos[1].position;

            }

         GameObject buf = Workers[0];
         
        
         Workers[1] = Workers[0];
         GameObject buf1 = Workers[1];
         Workers[0] = Workers[2];
   }
   
   void SecpndDirection()
   {
      Workers[1].transform.position =
         Vector3.MoveTowards(Workers[1].transform.position, stopPoints[1].position, _speed * Time.deltaTime);

     
      
   }
   void ThirdDirection()
   {
      Workers[2].transform.position =
         Vector3.MoveTowards(Workers[2].transform.position, stopPoints[2].position, _speed * Time.deltaTime);

     
      
   }
}
