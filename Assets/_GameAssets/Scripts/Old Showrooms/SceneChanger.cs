using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    GameObject thisObj;

    int currentSceneIndex = 0;

    public string sceneToOpen;

    float buttonHoldTimer = 0f;

    bool openSceneByName = false;

    public GameObject configuratorFiles;
    public GameObject avatar;

    private void Awake()
    {

        //if (thisObj != null && thisObj != this)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    thisObj = this.gameObject;

        //}

        //DontDestroyOnLoad(thisObj);

        //if (instance == null)
        //    instance = this;
    }

    private void OnEnable()
    {
        //Camera.main.GetComponent<OVRScreenFade>().FadeIn(); CHANGE

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered " + other.name);
        if (other.tag == "Player")
        {
            //avatar.SetActive(false);
            //configuratorFiles.SetActive(true);
            //avatar.transform.Translate(-2f, 0, 0);

            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None; ;

            openSceneByName = true;
            OpenNextSceneSlowly();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided " + collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            openSceneByName = true;

            OpenNextSceneSlowly();
        }
    }
    void Update()
    {

        //if (/* CHANGE OVRInput.Get(OVRInput.Button.One) */ Input.GetKey(KeyCode.LeftCommand))
        //{
        //    buttonHoldTimer += Time.deltaTime;
        //    if (buttonHoldTimer > 1f)
        //        OpenNextSceneSlowly();
        //}
        //else if (/*CHANGE OVRInput.Get(OVRInput.Button.Two) || */Input.GetKey(KeyCode.RightCommand))
        //{
        //    buttonHoldTimer += Time.deltaTime;

        //    if (buttonHoldTimer > 1f)
        //        OpenPrevSceneSlowly();
        //}
        //else
        //{
        //    if (buttonHoldTimer != 0)
        //        buttonHoldTimer = 0;
        //}
    }

    void OpenNextSceneSlowly()
    {

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (!PlayerPrefs.HasKey("sceneindex"))
            PlayerPrefs.SetInt("sceneindex", currentSceneIndex);



        currentSceneIndex++;

        Debug.Log("current scene index: " + currentSceneIndex);
        int allScenesCount = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex >= allScenesCount)
            currentSceneIndex = 0;

        //if (Camera.main.GetComponent<OVRScreenFade>()) CHANGE
        //    Camera.main.GetComponent<OVRScreenFade>().FadeOut();

        StartCoroutine(StartSceneLater());
    }

    void OpenPrevSceneSlowly()
    {

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex--;

        Debug.Log("current scene index: " + currentSceneIndex);
        int allScenesCount = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < 0)
            currentSceneIndex = SceneManager.sceneCount - 1;

        //if (Camera.main.GetComponent<OVRScreenFade>())  CHANGE
        //    Camera.main.GetComponent<OVRScreenFade>().FadeOut();

        StartCoroutine(StartSceneLater());
    }


    IEnumerator StartSceneLater()
    {
        yield return new WaitForSeconds(0.3f);


        //if (sceneToOpen.Length == 0)
        //    SceneManager.LoadScene(0);
        //else


        if (openSceneByName)
            SceneManager.LoadScene(sceneToOpen);
        else
            SceneManager.LoadScene(currentSceneIndex);

        openSceneByName = false;

    }
}
