using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;



public class ZoomCamera : MonoBehaviour
{
    public float min = 30f;
 public float max = 55f;
 public float sen = 8f;

 public CinemachineFreeLook vcam;
 
 void Update () {
  vcam.m_CommonLens = true;
   var fov = vcam.m_Lens.FieldOfView;
   fov -= Input.GetAxis("Mouse ScrollWheel") * sen;
   fov = Mathf.Clamp(fov, min, max);
   vcam.m_Lens.FieldOfView = fov;
 }
}
