using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class City : MonoBehaviour
{
    public int money;
    public int day;
    public int curPopulation;
    public int curJobs;
    public int curFood;
    public int maxPopulation;
    public int maxJobs;
    public int incomePerJob;

    public TextMeshProUGUI statsText;

    public List<Building> buildings;

    public static City Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateStatsText();
    }

    // called when we place down a building
    public void OnPlaceBuilding(Building building)
    {
        money -= building.preset.cost;
        maxPopulation += building.preset.population;
        maxJobs += building.preset.jobs;
        buildings.Add(building);
        UpdateStatsText();
    }

    // called when we bulldoze a building
    public void OnRemoveBuildng(Building building)
    {
        maxPopulation -= building.preset.population;
        maxJobs -= building.preset.jobs;
        buildings.Remove(building);
        // destroy the building
        Destroy(building.gameObject);

        UpdateStatsText();
    }

    // update the stats text
    public void UpdateStatsText()
    {
        statsText.text = string.Format("Day: {0}   Money: ${1}   Pop.: {2} / {3}   Jobs: {4} / {5}   Food: {6}", new object[7] { day, money, curPopulation, maxPopulation, curJobs, maxJobs, curFood});
    }

    public void EndTurn()
    {
        day++;
        CalculateMoney();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();

        UpdateStatsText() ;
    }

    void CalculateMoney()
    {
        money += curJobs * incomePerJob;
        foreach(Building building in buildings)
        {
            money -= building.preset.costPerTurn;
        }
    }

    void CalculatePopulation()
    {
        if(curFood >= curPopulation && curPopulation < maxPopulation)
        {
            curFood -= curPopulation / 4;
            curPopulation = Mathf.Min(curPopulation + (curFood / 4), maxPopulation);
        }
        else if (curFood< curPopulation)
        {
            curPopulation = curFood;
        }
    }

    void CalculateJobs()
    {
        curJobs = Mathf.Min(curPopulation, maxJobs);
    }

    void CalculateFood()
    {
        curFood = 0;
        foreach(Building building in buildings)
        {
            curFood += building.preset.food;
        }
    }
}


