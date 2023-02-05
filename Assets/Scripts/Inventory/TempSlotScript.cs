using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSlotScript : MonoBehaviour
{
    public void ButtonClicked()
    {
        Inventory.Instance.SellCatnip(gameObject.transform.GetSiblingIndex());
    }
}
