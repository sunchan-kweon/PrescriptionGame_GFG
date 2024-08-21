using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableUser : MonoBehaviour
{
    public GameObject item;

    public void useItem()
    {
        NeedsController.ChangeFood((int)item.GetComponent<Berry>().foodAmount);
        NeedsController.ChangeBlood((int)item.GetComponent<Berry>().bloodAmount);
        NeedsController.ChangeEnergy((int)item.GetComponent<Berry>().energyAmount);
        Inventory.items[item.GetComponent<Berry>().getId()]--;
        if (Inventory.items[item.GetComponent<Berry>().getId()] != 0)
        {
            gameObject.GetComponent<ItemController>().text.text = "x" + Inventory.items[item.GetComponent<Berry>().getId()];
        }
        else
        {
            Destroy(gameObject);
        }
        SaveSystem.SavePet();
    }

}
