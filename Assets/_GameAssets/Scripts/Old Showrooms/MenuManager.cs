using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UI.ProceduralImage;
using UnityEngine.Events;
using System;

public class MenuManager : MonoBehaviour
{


    [Serializable]
    public class Item
    {
        public string title;
        public GameObject item;
        public UnityEvent action;
        public bool requiresButton = false;
        public Sprite sprite;
        public float price = 0f;
        public string description;
    }

    [Serializable]
    public class category
    {
        public string name;
        public GameObject holder;
        public Item[] items;
        public int index;
    }

    public category[] categories;
    int index = 1;
    int xIndex = 0;
    bool isSwitched;
    public GameObject menu;

    public Transform selector;
    public Color mainColor;
    public Color selectedColor;

    public GameObject[] uiChanges;

    void Start()
    {
        switchCategory(index);
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     Vector2 move = Vector2.zero;//CHANGE OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

    //     if (!isSwitched)
    //     {
    //         if (move.y >= 0.7f && index > 0)
    //         {
    //             categories[index].index = xIndex;
    //             index--;
    //             switchCategory(index);
    //             isSwitched = true;
    //         }
    //         else if (move.y >= 0.7f && index <= 0)
    //         {
    //             categories[index].index = xIndex;
    //             index = categories.Length - 1;
    //             switchCategory(index);
    //             isSwitched = true;
    //         }
    //         else if (move.y <= -0.7f && index < categories.Length)
    //         {
    //             categories[index].index = xIndex;
    //             index++;
    //             switchCategory(index);
    //             isSwitched = true;
    //         }
    //         else if (move.y <= -0.7f && index >= categories.Length)
    //         {
    //             index = 0;
    //             switchCategory(index);
    //             isSwitched = true;
    //         }
    //         else if (move.x <= -0.7f && xIndex > 0 && index > 0)
    //         {
    //             xIndex--;
    //             switchItem(xIndex);
    //             isSwitched = true;
    //         }
    //         else if (move.x <= -0.7f && xIndex <= 0 && index > 0)
    //         {
    //             xIndex = categories[index].items.Length - 1;
    //             switchItem(xIndex);
    //             isSwitched = true;
    //         }
    //         else if (move.x >= 0.7f && xIndex < categories[index].items.Length && index > 0)
    //         {
    //             xIndex++;
    //             switchItem(xIndex);
    //             isSwitched = true;
    //         }
    //         else if (move.x >= 0.7f && xIndex >= categories[index].items.Length && index > 0)
    //         {
    //             xIndex = 0;
    //             switchItem(xIndex);
    //             isSwitched = true;
    //         }
    //     }
    //     if (move.y < 0.7f && move.y > -0.7f && move.x < 0.7f && move.x > -0.7f)
    //     {
    //         isSwitched = false;
    //     }

    //     //if (OVRInput.Get(OVRInput.Button.One)) CHANGE
    //     //{
    //     //    categories[index].items[xIndex].action.Invoke();
    //     //}

    //     if(index == 0){
    //         gameObject.transform.Rotate(-Vector3.up * move.x);
    //     }

    //     // if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
    //     // {
    //     //     menu.SetActive(!menu.activeSelf);
    //     // }


    // }


    public void switchCategory(int ind)
    {
        index = ind;
        foreach (var cat in categories)
        {
            //cat.holder.GetComponent<ProceduralImage>().color = mainColor;CHANGE
            foreach (var item in cat.items)
            {
                item.item.SetActive(false);
            }
        }

        var category = categories[index];
        xIndex = category.index;
        switchItem(xIndex);
        //category.holder.GetComponent<ProceduralImage>().color = selectedColor; CHANGE
        foreach (var item in category.items)
        {
            item.item.SetActive(true);
            item.item.transform.localPosition = new Vector3(item.item.transform.localPosition.x, item.item.transform.localPosition.y, 0);
        }
        selector.transform.position = category.items[category.index].item.transform.position;

        var itemPosition = category.items[category.index].item.transform.localPosition;
        category.items[category.index].item.transform.localPosition = new Vector3(itemPosition.x, itemPosition.y, 3);
    }

    public void switchItem(int itemTo)
    {
        var category = categories[index];
        var item = category.items[itemTo];
        category.index = itemTo;
        selector.transform.position = item.item.transform.position;
        foreach (var i in category.items)
        {
            i.item.transform.localPosition = new Vector3(i.item.transform.localPosition.x, i.item.transform.localPosition.y, 0);
        }

        var itemPosition = category.items[itemTo].item.transform.localPosition;
        category.items[itemTo].item.transform.localPosition = new Vector3(itemPosition.x, itemPosition.y, 3);
        if (!item.requiresButton)
        {
            item.action.Invoke();
        }

        uiChanges[0].GetComponent<Image>().sprite = item.sprite;
        uiChanges[1].GetComponent<TextMeshProUGUI>().text = item.title;
        uiChanges[2].GetComponent<TextMeshProUGUI>().text = item.description;
    }
}
