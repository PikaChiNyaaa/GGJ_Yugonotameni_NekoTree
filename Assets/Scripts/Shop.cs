using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Item[] ShopItems;

    public void BuyItem(string name)
    {
        foreach (Item item in ShopItems)
        {
            if (item.name == name)
            {
                Inventory.Instance.Add(item, 1);
                break;
            }
        }
    }
}
