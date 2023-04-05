using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraDOF_Manager : MonoBehaviour
{

    public Volume postProcessVolume;
    public Transform allPosParent;
    public CameraDOF_ByPosition[] allPositions;

    public float transitionSpeed = 1f;
    private DepthOfField depthOfField;

    int lastCalled = 0;

    bool updateDoFValue = false;

    float focusValue = 0f;
    private void Start()
    {
        postProcessVolume.profile.TryGet(out depthOfField);

        allPositions = new CameraDOF_ByPosition[allPosParent.childCount];
        for (int i = 0; i < allPosParent.childCount; i++)
        {
            allPositions[i] = allPosParent.GetChild(i).GetComponent<CameraDOF_ByPosition>();
        }
    }

    private void Update()
    {
      //  if (updateDoFValue)
      //  {
      //      depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, focusValue, transitionSpeed);
      //          if (Mathf.Abs(depthOfField.focusDistance.value - focusValue ) < 0.001f)
      //          updateDoFValue = false;
      //  }
    }
    public void ModifyFocus()
    {
        focusValue = allPositions[lastCalled].getDoFvalue();
        updateDoFValue = true;
        lastCalled++;

        if (lastCalled == allPositions.Length)
            lastCalled = 0;
    }

    //IEnumerator ModifyFocusAfter()
    //{
    //    yield return new WaitForSeconds(1);

    //    allPositions[lastCalled].ModifyFocusDistance();
    //    lastCalled++;

    //    if (lastCalled == allPositions.Length)
    //        lastCalled = 0;
    //}
}
