using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public Plant plant { get; private set; }

    PlantStateSet currPlantState;

    public bool isWatered { get; private set; }
    public bool isPlowed { get; private set; }


}
