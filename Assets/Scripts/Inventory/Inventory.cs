using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Make Inventory a Singleton
    public static Inventory Instance { get; private set; }

    [SerializeField] GameObject SlotPrefab, SlotParent;
    [SerializeField] TextMeshProUGUI MoneyText;

    public int Money { get; private set; }

    // Dictionary for Each Item and number of items
    public Dictionary<Item, InventorySlot> Items;

    private void Awake()
    {
        // If there is an instance, and it is not this instance, delete this
        // Deletes new instances aside from initial

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Items = new();
        Money = 100000;
    }

    private void Update()
    {
        MoneyText.text = "$" + Money.ToString();
    }

    public void Add(Item item, int num)
    {
        if (Items.ContainsKey(item))
        {
            Items[item].count += num;
        }
        else
        {
            InventorySlot slot = new()
            {
                obj = Instantiate(SlotPrefab, SlotParent.transform)
            };
            slot.obj.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            slot.countText = slot.obj.transform.Find("Count").GetComponentInChildren<TextMeshProUGUI>();
            slot.count = num;

            Items.Add(item, slot);
        }

        if (Items[item].count <= 100)
            Items[item].countText.text = Items[item].count.ToString();
        else
            Items[item].countText.text = "99+";
    }

    public bool Remove(Item item, int num)
    {
        /* Returns true if the item has been successfully removed
         * 
         * Returns false if:
         * - There is not enough items in the inventory
         * - Item is not in the inventory
         */

        if (Items.ContainsKey(item))
        {
            int remainder = Items[item].count - num;

            if (remainder < 0)
                return false;
            else if (remainder == 0)
            {
                Destroy(Items[item].obj);
                Items.Remove(item);
            }
            else if (remainder > 0)
            {
                Items[item].count = remainder;
            }
            return true;
        }
        return false;
    }

    public bool PayMoney(int amount)
    {
        /* Returns true if player has enough money*/

        if (Money >= amount)
        {
            Money -= amount;
            return true;
        }
        else
            return false;
    }
}


public class InventorySlot
{
    public GameObject obj;

    public int count;

    public TextMeshProUGUI countText;
}


