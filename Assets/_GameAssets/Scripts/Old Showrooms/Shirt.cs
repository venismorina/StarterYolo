using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shirt : MonoBehaviour
{

    public BodyShirt bodyParent;

    public GameObject bodyShirt;
    public GameObject UpdateShirtWithBody()
    {

        bodyParent.ResetShirts();
        GameObject newShirt = Instantiate(bodyShirt, bodyParent.GetShirtsParentTransform());

        return newShirt;
    }


}
