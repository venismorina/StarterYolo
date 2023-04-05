using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{

    public Vector3 rotationDirection = new Vector3(0,1,0);

    public Transform centerOfRotation;
    [Range(1, 100)]
    public float speedMultiplier = 10f;
    void Update()
    {
        transform.RotateAround(centerOfRotation.position, rotationDirection, Time.deltaTime * speedMultiplier);
    }
}
