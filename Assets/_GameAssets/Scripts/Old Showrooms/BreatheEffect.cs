using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheEffect : MonoBehaviour
{

    public float breatheSpeed = 0.5f;
    public float breatheChangeValue = 0.1f;

    [SerializeField] bool breathingNow = false;



    public Vector3 firstScale;

    Shirt thisShirt;
    float breatheDirection = -1f;

    GameObject lastShirt;
    private void Start()
    {
        firstScale = transform.localScale;
        thisShirt = GetComponent<Shirt>();
    }
    void Update()
    {
        if (breathingNow)
        {
            Breathe();
        }
        else
        {
            ResetBreathing();
            breathingNow = false;
        }
    }


    void Breathe()
    {
        if (transform.localScale.x > firstScale.x + breatheChangeValue)
        {
            breatheDirection = -firstScale.x;
        }
        else if (transform.localScale.x < firstScale.x)
        {
            breatheDirection = firstScale.x;
            StopBreathing();
        }

        transform.localScale += firstScale * Time.deltaTime * breatheSpeed * breatheDirection;


        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || Input.GetKeyDown(KeyCode.LeftControl)) CHANGE
        //{
        //    if(thisShirt != null)
        //        thisShirt.UpdateShirtWithBody();
        //}

    }

    void ResetBreathing()
    {
        transform.localScale = firstScale;
    }
    public void StartBreathing()
    {
        breathingNow = true;
    }
    public void StopBreathing()
    {
        breathingNow = false;
    }

    
}
