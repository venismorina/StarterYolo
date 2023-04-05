using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAtStart : MonoBehaviour
{
    public string sceneName;
    void Awake()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }


}
