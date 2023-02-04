using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] PlotParts plot;
    [SerializeField] Plant catnip;

    public Plant plant { get; private set; }
    public bool isWatered { get; private set; }

    float currTimeLapse; // Time Lapse per Plant State
    Plant.PLANT_STATE_TYPE currPlantState;

    private void Start()
    {
        plant = null;
        isWatered = false;
        currTimeLapse = -1;
        currPlantState = Plant.PLANT_STATE_TYPE.SEEDLING;
    }

    // TODO: Re structure how players choose their plant
    public void PlotClicked()
    {
        if (plant == null)
        {
            if(Inventory.Instance.Remove(1, null, "CatnipSeeds"))
            {
                plant = catnip;
                plot.plantStates.seedling.SetActive(true);
                currPlantState = Plant.PLANT_STATE_TYPE.SEEDLING;
                currTimeLapse = -1;
            }
        }
        else if (currPlantState == Plant.PLANT_STATE_TYPE.GROWN)
        {
            foreach (Item crop in plant.crops)
            {
                int cropYield = UnityEngine.Random.Range(plant.minRange, plant.maxRange);
                Inventory.Instance.Add(crop, cropYield);
            }
            plot.plantStates.grown.SetActive(false);
            plant = null;

        }
        else if (plant != null && !isWatered)
        {
            isWatered = true;

            switch (currPlantState)
            {
                case Plant.PLANT_STATE_TYPE.SEEDLING:
                    currTimeLapse = plant.plantStateSet.seedling.time;
                    break;
                case Plant.PLANT_STATE_TYPE.GROWING:
                    currTimeLapse = -1;
                    break;

            }
        }
    }

    private void FixedUpdate()
    {
        if (currTimeLapse > 0)
        {
            currTimeLapse -= Time.time;
        }
        else if (plant!= null && currPlantState != Plant.PLANT_STATE_TYPE.GROWN)
        {
            isWatered = false;
            currTimeLapse = -1;

            switch (currPlantState)
            {
                case Plant.PLANT_STATE_TYPE.SEEDLING:
                    plot.plantStates.seedling.SetActive(false);
                    plot.plantStates.growing.SetActive(true);
                    currPlantState = Plant.PLANT_STATE_TYPE.GROWING;
                    break;
                case Plant.PLANT_STATE_TYPE.GROWING:
                    plot.plantStates.growing.SetActive(false);
                    plot.plantStates.grown.SetActive(true);
                    currPlantState = Plant.PLANT_STATE_TYPE.GROWN;
                    break;

            }
        }
    }

}

[System.Serializable]
public struct PlotParts
{
    public GameObject soil;
    public GameObject wetSoil;
    public PlantStateObjs plantStates;

}

[System.Serializable]
public struct PlantStateObjs
{
    public GameObject seedling;
    public GameObject growing;
    public GameObject grown;
}
