using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class CameraDOF_ByPosition : MonoBehaviour
{

    public float focusValue;


    private void Start()
    {
    
    }


    private void Update()
    {

        //if (updateDoFValue )
        //{
        //    if (depthOfField.focusDistance.value > focusValue)
        //    {
        //        depthOfField.focusDistance.value += 0.01f;


        //    } 
        //    else if (depthOfField.focusDistance.value < focusValue)
        //    {
        //        depthOfField.focusDistance.value -= 0.01f;

        //    }
        //    if (depthOfField.focusDistance.value == focusValue)
        //        updateDoFValue = false;
        //}
      
        //    depthOfField.focusDistance.value += // Mathf.Lerp(depthOfField.focusDistance.value, focusValue, transitionSpeed);
        //    if (depthOfField.focusDistance.value == focusValue)
        //        updateDoFValue = false;

        //    Debug.Log("Updated dof:" + depthOfField.focusDistance.value);
        //    timeBetween = 0f;
        //}
        //timeBetween += Time.deltaTime;
    }

    public float  getDoFvalue()
    {
        return focusValue;
    }
}
