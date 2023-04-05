using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouseOnStart : MonoBehaviour
{
    public bool lockCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        if (lockCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; ;

        }
    }

    public void LockCursor()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }
}
