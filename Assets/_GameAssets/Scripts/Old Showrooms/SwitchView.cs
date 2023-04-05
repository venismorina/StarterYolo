using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    public GameObject outsideView;
    public GameObject insideView;
   

    public void viewCar()
    {
       outsideView.SetActive(true);
       insideView.SetActive(false);
    }

    public void viewIn()
    {
       outsideView.SetActive(false);
       insideView.SetActive(true);
        Cursor.visible = true;
    }

    public void exit(){
        Debug.Log("Exited");
    }


}
