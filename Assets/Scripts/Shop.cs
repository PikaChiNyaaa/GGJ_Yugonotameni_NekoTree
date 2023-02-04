using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Item[] shopItems;

    [SerializeField] GameObject[] roomBtnList;
    [SerializeField] GameObject[] roomList;

    static readonly int[] roomPrices = { 100, 500, 1000, 2000 };

    public void BuyItem(string name)
    {
        foreach (Item item in shopItems)
        {
            if (item.name == name)
            {
                if (Inventory.Instance.PayMoney(item.price))
                    Inventory.Instance.Add(item, item.quantity);
                break;
            }
        }
    }

    public void BuyRoom(int roomNum)
    {
        // Rooms for sale start from room 2

        if (roomNum >= 2 && roomNum <= 3)
        {
            if (Inventory.Instance.PayMoney(roomPrices[roomNum - 2]))
            {
                roomList[roomNum - 2].SetActive(true);
                roomBtnList[roomNum - 2].SetActive(true);
            }
        }
    }

}
