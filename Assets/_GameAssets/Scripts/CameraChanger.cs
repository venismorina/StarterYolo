using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public bool disableClickChangeCam = false;
    [SerializeField] GameObject fpsController;
    [SerializeField] Camera secondCamera;
    [SerializeField] Camera fpsCamera;

    [SerializeField] GameObject cameraPoints;
    [SerializeField] GameObject editingCameraPoint;
    [SerializeField] [Range(0.1f, 10f)] float animationSpeed = 1f;


    Transform OldTransform;
    Transform newTransform;

    int index = 0;
    bool updateCameraPosition = false;

    private void Start()
    {
        if (disableClickChangeCam)
        {
            ChangeCameraPosition();
        }
    }
    private void Update()
    {
        if (updateCameraPosition)
        {

            secondCamera.transform.position = Vector3.Lerp(OldTransform.position, newTransform.position, Time.deltaTime * animationSpeed);
            secondCamera.transform.rotation = Quaternion.Lerp(OldTransform.rotation, newTransform.rotation, Time.deltaTime * animationSpeed);

            

            if (Vector3.Distance(secondCamera.transform.position, newTransform.position) < 0.1f)
                updateCameraPosition = false;
        }

        if (Input.GetMouseButtonDown(0) && !disableClickChangeCam)
        {
            ChangeCameraPosition();
        }
    }

    public void ChangeCameraPosition()
    {
        secondCamera.orthographic = false;

        if (index == cameraPoints.transform.childCount)
            index = 0;


        if (fpsController.activeSelf)
        {
            fpsController.SetActive(false);
            secondCamera.gameObject.SetActive(true);

            secondCamera.transform.position = fpsCamera.transform.position;
            secondCamera.transform.rotation = fpsCamera.transform.rotation;
            Cursor.visible = true;
        }

        OldTransform = secondCamera.transform;

        newTransform = cameraPoints.transform.GetChild(index).transform;

        index++;
        updateCameraPosition = true;
    }

    private void MetodaTest()
    {

    }


    public void SetEditingView()
    {
        secondCamera.orthographic = false;


        if (fpsController.activeSelf)
        {
            fpsController.SetActive(false);
            secondCamera.gameObject.SetActive(true);

            secondCamera.transform.position = fpsCamera.transform.position;
            secondCamera.transform.rotation = fpsCamera.transform.rotation;
            Cursor.visible = true;

            //secondCamera.fieldOfView = 
        }

        OldTransform = secondCamera.transform;

        newTransform = cameraPoints.transform.GetChild(index).transform;

        updateCameraPosition = true;
    }

    public void SetCustomView(Transform view)
    {
        OldTransform = secondCamera.transform;

        newTransform = view;

        if (index > 0)
            index--;

        updateCameraPosition = true;
    }

    public void EnableFPSCamera()
    {
        StartCoroutine(EnableAfterSec());
    }

    IEnumerator EnableAfterSec()
    {
        yield return new WaitForSeconds(1.8f);

        fpsController.SetActive(true);
        secondCamera.gameObject.SetActive(false);
    }

}
