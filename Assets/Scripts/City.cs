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
        statsText.text = "Day: " + day + "\n" +
                         "Money: " + money + "\n" +
                         "Population: " + curPopulation + "/" + maxPopulation + "\n" +
                         "Jobs: " + curJobs + "/" + maxJobs + "\n" +
                         "Food: " + curFood + "\n";
    }
}


