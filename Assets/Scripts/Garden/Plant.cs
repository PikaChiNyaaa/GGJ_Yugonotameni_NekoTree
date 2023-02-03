using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public new string name;
    public string description;

    public int price;

    public PlantStateSet plantStateSet;
}

[System.Serializable]
public struct PlantStateSet
{
    public PlantState seed;
    public PlantState growing;
    public PlantState grown;
}

[System.Serializable]
public struct PlantState
{
    public Sprite stateImage;
    [Tooltip("Time before the plant changes into its next state")]
    public float time;
}
