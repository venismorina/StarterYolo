using UnityEngine;

public class TriggerEnable : MonoBehaviour
{
    public Animator objToEnable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controllers")
        {
            objToEnable.SetTrigger("ShowSpecs");
        }
    }
}
