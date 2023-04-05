using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public Material mainColor;
    public Gradient gradient;
    bool isLooping;
    public Material frontLight;
    public GameObject[] lights;
    public Transform[] wheelHolders;

    public Animator DoorsAnimator;



    public void switchColor(string color)
    {
        isLooping = false;
        Color newCol;

        if (ColorUtility.TryParseHtmlString("#" + color, out newCol))
        {
            mainColor.color = newCol;
        }

        if (color == "gradient")
        {
            isLooping = true;
        }
    }

    float x = 0;
    void Update()
    {
        if (isLooping)
        {
            if (x < 0.999f)
            {
                x += 0.001f;
                mainColor.color = gradient.Evaluate(x);
            }
            else
            {
                x = 0;
            }
        }
    }

    public void changeWheel(int index)
    {
        foreach (var wheelHolder in wheelHolders)
        {
            for (int i = 0; i < 5; i++)
            {
                wheelHolder.GetChild(i).gameObject.SetActive(false);
            }
            wheelHolder.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void switchLights(bool on)
    {
        if (on)
        {
            // lights[0].SetActive(true);
            // lights[1].SetActive(true);
            frontLight.EnableKeyword("_EMISSION");
        }
        else
        {
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            frontLight.DisableKeyword("_EMISSION");
        }

    }

    public void openDoors(){
         DoorsAnimator.SetBool("CloseDoors", false);
       DoorsAnimator.SetBool("OpenDoors", true);
    }

    public void closeDoors(){
       DoorsAnimator.SetBool("CloseDoors", true);
       DoorsAnimator.SetBool("OpenDoors", false);

    }

}
