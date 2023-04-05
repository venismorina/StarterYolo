using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateWithDrag : MonoBehaviour
{
    public float _rotationSpeed = 100.0f;
    private float _rotationY = 0.0f;
    private float _rotationX = 0.0f;
    private Vector3 _rotation;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _rotationX -= Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            //_rotationY -= Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime * 0.1f;
            _rotation = new Vector3(_rotationY, _rotationX, 0.0f);

           
            transform.eulerAngles = _rotation;
        }
    }
}
