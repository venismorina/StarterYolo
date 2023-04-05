using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationSlideShow : MonoBehaviour
{

    public Sprite[] allSprites;
    public SpriteRenderer spriteShower;
    int index = 0;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteShower.enabled)
        {
            timer += Time.deltaTime;
            if(timer > 5f)
            {
                UpdateScreen();
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnableScreen(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
      if (other.tag == "Player")
        {
            EnableScreen(false);
        }
    }

    void EnableScreen(bool enable_disable)
    {
        spriteShower.gameObject.SetActive(enable_disable);
    }

    void UpdateScreen()
    {
        spriteShower.sprite = allSprites[index];
        index++;

        if (index >= allSprites.Length)
            index = 0;

    }
}
