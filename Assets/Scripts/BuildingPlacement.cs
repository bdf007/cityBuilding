using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private bool currentlyPlacing;
    private bool currentlyBuldozering;

    private BuildingPreset curBuildingPreset;


    private float indicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curIndicatorPos;

    public GameObject placementIndicator;
    public GameObject buldozerIndicator;

    private void Update()
    {
        // cancel building placement if we press escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }
        if(Time.time - lastUpdateTime > indicatorUpdateRate)
        {
            lastUpdateTime = Time.time;
            curIndicatorPos = Selector.Instance.GetCurTilePosition();

            // update the placement indicator
            if( currentlyPlacing)
            {
                placementIndicator.transform.position = curIndicatorPos;
            }
            else if(currentlyBuldozering ) {
                buldozerIndicator.transform.position = curIndicatorPos;
            }
        }

        // called when we press left mouse button
        if(Input.GetMouseButtonDown(0) && currentlyPlacing)
        {
            PlaceBuilding();
        }
        else if(Input.GetMouseButtonDown(0) && currentlyBuldozering)
        {
            Buldoze();
        }
    }

    private void Buldoze()
    {
        
    }

    // called when we press a building UI button
    public void BeginNewBuildingPlacement(BuildingPreset preset)
    {
        // make sure we have enough money

        currentlyPlacing = true;
        curBuildingPreset = preset;
        placementIndicator.SetActive(true);
        placementIndicator.transform.position = new Vector3(0, -99, 0);
    }

    // called when we place down a building or press Escape
    void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    // turn bulldoze on or off
    public void ToggleBuldoze()
    {
        currentlyBuldozering = !currentlyBuldozering;
        buldozerIndicator.SetActive(currentlyBuldozering);
        buldozerIndicator.transform.position = new Vector3(0, -99, 0);
    }

    // places down the currently selected building
    void PlaceBuilding()
    {
        GameObject buildingObj = Instantiate(curBuildingPreset.prefab, curIndicatorPos, Quaternion.identity);

        // tell city script

        CancelBuildingPlacement();
    }
}
