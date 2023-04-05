using UnityEngine;

public class VRUITestings : MonoBehaviour
{
    public Material objMaterial;

    public Color pointerEnterColor;
    public Color normalColor;
    public Color clickColor;

    public Transform pos;
    public Camera mainCamera;
    public float rayLength;
    public RaycastHit hittedObject;

    public GameObject hittedObj;
    public GameObject lastHittedObj;

    public LineRenderer lineTest;

    public BreatheEffect be;


    private void Start()
    {
        //  objMaterial = GetComponent<Material>();

        be = GetComponent<BreatheEffect>();
    }

    public void PointerEntered()
    {
        objMaterial.color = pointerEnterColor;
    }

    public void PointerExited()
    {
        objMaterial.color = normalColor;
    }

    public void PointerClicked()
    {
        objMaterial.color = clickColor;
        transform.Translate(0, 1, 0);
    }
    private void Update()
    {
        GetHittedPoint();
    }

    Vector3 GetHittedPoint()
    {

        Ray crosshair = new Ray(pos.position, pos.forward);


        Vector3 aim;
        if (Physics.Raycast(crosshair, out hittedObject, rayLength))
        {
            aim = hittedObject.point;


        }
        else
        {
            aim = crosshair.origin + crosshair.direction * rayLength;
        }

        Ray beam = new Ray(pos.position, aim - pos.position);

        if (!Physics.Raycast(beam, out hittedObject, rayLength))
            return aim;

        hittedObj = hittedObject.transform.gameObject;

        if (hittedObj.layer == 14)
        {
            lineTest.SetPosition(0, pos.position);
            lineTest.SetPosition(1, hittedObj.transform.position);
            //Debug.Log("00000000000000000000000");
            hittedObj.GetComponent<BreatheEffect>().StartBreathing();
            be.StartBreathing();
            lastHittedObj = hittedObj;
        }
        else
        {
            //lastHittedObj.GetComponent<BreatheEffect>().StopBreathing();


        }
        //lineTest.SetPosition(0, pos.position);
        //lineTest.SetPosition(1, hittedObj.transform.position);

        return hittedObject.point;
    }
}
