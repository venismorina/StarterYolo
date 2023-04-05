using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechRaycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Transform player;
    public Transform playerCamera;
    public Transform techPoint;
    public Transform camPoint;
    public Transform camera;

    public float animationSpeed = 2f;

    Transform OldTransform;
    Transform newTransform;

    bool updateCameraPosition;
        Animator Anim = null;


    void Update()
    {
        if (player.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.name);
                    if (hit.collider.tag == "tech")
                    {
                        var isLeft = hit.transform.gameObject.GetComponent<TechCameraAngle>().left;
                        try{
                        Anim = hit.transform.gameObject.GetComponent<TriggerEnable>().objToEnable;
                        Anim.SetTrigger("ShowSpecs");

                        }catch{}

                        techPoint.localEulerAngles = new Vector3(0, isLeft ? 180 : 0, 0);
                        techPoint.position = hit.transform.GetChild(0).position;

                        camera.transform.position = playerCamera.transform.position;
                        camera.transform.rotation = playerCamera.transform.rotation;
                        Cursor.visible = true;

                        player.gameObject.SetActive(false);
                        techPoint.gameObject.SetActive(true);

                        // camPoint.LookAt(techPoint.transform, isLeft ? Vector3.left : Vector3.right);

                        OldTransform = camera.transform;
                        newTransform = camPoint.transform;


                        updateCameraPosition = true;

                    }
                }

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(Anim){
                    Anim.SetTrigger("HideSpecs");
                }

                player.gameObject.SetActive(true);
                techPoint.gameObject.SetActive(false);
            }
        }

        if (updateCameraPosition)
        {

            camera.transform.position = Vector3.Lerp(OldTransform.position, newTransform.position, Time.deltaTime * animationSpeed);
            camera.transform.rotation = Quaternion.Lerp(OldTransform.rotation, newTransform.rotation, Time.deltaTime * animationSpeed);


            if (Vector3.Distance(camera.transform.position, newTransform.position) < 0.05f)
                updateCameraPosition = false;
        }
    }
}
