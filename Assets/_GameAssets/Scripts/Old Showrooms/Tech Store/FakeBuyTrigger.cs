using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBuyTrigger : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controllers")
        {
            animator.SetTrigger("HideSpecs");
        }
    }
}
