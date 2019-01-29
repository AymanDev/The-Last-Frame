using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class RandomRotator : MonoBehaviour
 {
     private void Start()
     {
         var randDir = Random.Range(0, 100);
         if(randDir >= 50) transform.eulerAngles = new Vector3(0f, 180f, 0f);
     }
 }