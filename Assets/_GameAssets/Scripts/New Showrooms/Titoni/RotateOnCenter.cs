using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnCenter : MonoBehaviour
{

    public Vector3 direction;
    public float speed = 5f;
    void Update()
    {
        transform.Rotate(direction*Time.deltaTime* speed);
    }
}
