using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public enum PLANT_STATE_TYPE
    { 
        SEEDLING = 0,
        GROWING,
        GROWN
    }

    public new string name;
    public string description;

    public PlantStateSet plantStateSet;

    public List<Item> crops = new();

    [Tooltip("Min number of crop yield")]
    public int minRange = 1;
    [Tooltip("Max number of crop yield")]
    public int maxRange = 1;
}

[System.Serializable]
public struct PlantStateSet
{
    public PlantState seedling;
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
