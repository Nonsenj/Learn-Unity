using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShopManager : MonoBehaviour
{
    float Pocket = 300;
    public InventoryManager inventoryManager;
    public PlantObject[] itemsToPickup; //item
    public TMP_Text Money;

    private void Start()
    {
        Money.text = "$" + Pocket.ToString();
        
    }

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("Item added");
            Pocket = Pocket - itemsToPickup[id].price;
            Money.text = "$" + Pocket.ToString();
        }
        else
        {
            Debug.Log("Item not added");
        }

    }


}
