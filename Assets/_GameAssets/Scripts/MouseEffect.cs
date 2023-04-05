using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour {

    public float multiplyer = 1000;

    float screenWidth;
    float screenHeigh;

    public float percentageOfMovement = 100f;
	void Start () {
        screenWidth = Screen.width/2f;
        screenHeigh = Screen.height/2f;

    }
	
	// Update is called once per frame
	void Update () {
        CameraEffectUpdate();

    }


    void CameraEffectUpdate()
    {
        float yRotation = (Input.mousePosition.x - screenWidth) / multiplyer;
        float xRotation = (Input.mousePosition.y - screenHeigh) / multiplyer;
        Quaternion newRotation = Quaternion.Euler(
            -xRotation/ percentageOfMovement + transform.rotation.x, 
            yRotation/ percentageOfMovement + transform.rotation.y, 
            0);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
    }


}
