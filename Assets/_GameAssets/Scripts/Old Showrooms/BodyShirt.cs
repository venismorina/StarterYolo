using UnityEngine;

public class BodyShirt : MonoBehaviour
{
    public Transform shirtsParent;
    public void ResetShirts()
    {
        if(shirtsParent.childCount > 0)
        {
            for (int i = 0; i < shirtsParent.childCount; i++)
            {
                Destroy(shirtsParent.GetChild(0).gameObject);
            }
        }

        
    }

    public Transform GetShirtsParentTransform()
    {
        return shirtsParent;
    }
}
