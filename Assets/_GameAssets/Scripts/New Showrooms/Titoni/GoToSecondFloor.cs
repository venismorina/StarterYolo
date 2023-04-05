using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSecondFloor : MonoBehaviour
{

    public Transform secondFloorPosition;
    public Transform firstFloorPosition;

    public bool startMoving = false;
    public float speed = 1f;
    private void Update()
    {
        
        if(startMoving)
        {

            firstFloorPosition.position = Vector3.Lerp(firstFloorPosition.position, secondFloorPosition.position, speed);

            if(firstFloorPosition.position.y > secondFloorPosition.position.y - 1f)
            {
                startMoving = false;

                firstFloorPosition.position = new Vector3(firstFloorPosition.position.x, 29.711f, firstFloorPosition.position.z);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered " + other.name);
        if (other.tag == "Player")
        {
            //firstFloorPosition.position = secondFloorPosition.position;
            startMoving = true;
        }

    }
}
