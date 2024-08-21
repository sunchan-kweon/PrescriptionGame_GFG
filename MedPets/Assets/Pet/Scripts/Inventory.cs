using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int[] items;
    private static bool started = false;
    public bool isInventory;
    public GameObject itemPrefab;
    public BerryHolder holder;


    private void Start()
    {
        if(started == false)
        {
            items = new int[holder.getSize()];
            started = true;
        }
        if (isInventory)
        {
            LoadItems();
        }
    }

    public void LoadItems()
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != 0)
            {
                GameObject current = Instantiate(itemPrefab, gameObject.transform);
                current.GetComponent<ItemController>().text.text += items[i];
                current.GetComponent<ItemController>().button.sprite = holder.getBerry(i).GetComponent<Image>().sprite;
                current.GetComponent<ItemController>().GetComponent<ConsumableUser>().item = holder.getBerry(i);
            }
        }
    }
}
