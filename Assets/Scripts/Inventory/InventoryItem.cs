using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public int price;

    //Can be null
    public Plant plant;

}