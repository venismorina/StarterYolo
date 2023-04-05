using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesRaycast : MonoBehaviour
{
    Ray ray;
     RaycastHit hit;
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
            if(hit.collider.tag == "cloth"){
                hit.transform.gameObject.GetComponent<BreatheEffect>().StartBreathing();
                if(Input.GetMouseButtonDown(0)){
                    hit.transform.gameObject.GetComponent<Shirt>().UpdateShirtWithBody();
                    
                }
            }
            
         }
     }
}
