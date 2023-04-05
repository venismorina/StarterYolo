using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float RotationSpeed = 5;
    public float rotatespeed = 10f;
    private float startingPosition;
    void Start()
    {

    }

    void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetMouseButton(0))
            transform.Rotate(0, (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);

#else
  if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (startingPosition > touch.position.x)
                    {
                        transform.Rotate(Vector3.down, rotatespeed * Time.deltaTime);
                    }
                    else if (startingPosition < touch.position.x)
                    {
                        transform.Rotate(Vector3.down, -rotatespeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }
#endif

    }
}

