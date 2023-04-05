using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableNoParent : MonoBehaviour
{
    private void OnEnable()
    {
        transform.parent = null;
    }
}
