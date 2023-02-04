using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    [Tooltip("Price of the Item in the Shop")]
    public int price;

    //Can be null
    public Plant plant;

}