using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public int curTurn;
   public bool placingBuilding = true;
   public BuildingType curSelectedBuilding;

  [Header("Current Resources")]
  public int curFood;
  public int curMetal;
  public int curOxygen;
  public int curEnergy;

  [Header("Current Resources")]
  public int foodPerTurn;
  public int metalPerTurn;
  public int oxygenPerTurn;
  public int energyPerTurn;

  public static GameManager instance;

  void Awake () {
      instance = this;
  }

  void Start () {
      UI.instance.UpdateResourceText();

  }

  public void EndTurn () {
    curFood += foodPerTurn;
    curMetal += metalPerTurn;
    curOxygen += oxygenPerTurn;
    curEnergy += energyPerTurn;

    curTurn++;

    // enable the building buttons
    UI.instance.ToggleBuildingButtons(true); 
    // enable usable tiles
    Map.instance.EnableUsableTiles();
  }

  public void SetPlacingBuilding (BuildingType buildingType)
  {
      placingBuilding = true;
      curSelectedBuilding = buildingType;
  }

    public void OnCreatedNewBuilding(Building building)
    {
        if (building.DoesProduceResourse)
        {
            switch (building.productionResource)
            {

                case ResourceType.Food:
                    foodPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Metal:
                    metalPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Oxygen:
                    oxygenPerTurn += building.productionResourcePerTurn;
                    break;

                case ResourceType.Energy:
                    energyPerTurn += building.productionResourcePerTurn;
                    break;

            }
        }

        if(building.hasMaintenanceCost){
            switch (building.maintenanceResource)
            {

                case ResourceType.Food:
                    foodPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Metal:
                    metalPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Oxygen:
                    oxygenPerTurn += building.maintenanceResourcePerTurn;
                    break;

                case ResourceType.Energy:
                    energyPerTurn += building.maintenanceResourcePerTurn;
                    break;

            }

      }

    placingBuilding = false;
    UI.instance.UpdateResourceText();
  }
}
