using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
   public List<Tile> tiles = new List<Tile>();
   public List<Building> buildings = new List<Building>();

   public float tileSize;

    public List<Building> buildingPrefabs = new List<Building>();


    public static Map instance;

    void Awake() {
        instance = this;
        
    }

    void Start () {
        EnableUsableTiles();
    }

    public void EnableUsableTiles (){
        foreach(Building building in buildings)
        {
            Debug.Log("building.transform.position" + building.transform.position);
            Tile northTile = GetTileAtPosition(building.transform.position + new Vector3(0, tileSize, 0));
            Tile southTile = GetTileAtPosition(building.transform.position + new Vector3(0, -tileSize, 0));
            Tile westTile = GetTileAtPosition(building.transform.position + new Vector3(-tileSize, 0, 0));
            Tile eastTile = GetTileAtPosition(building.transform.position + new Vector3(tileSize, 0, 0));
            // Debug.Log("North " + northTile?.transform.position);
            // Debug.Log("norht pos" + (building.transform.position + new Vector3(0, tileSize, 0)));
            // Debug.Log("south " + southTile);
            // Debug.Log("East " + eastTile);
            // Debug.Log("West " + westTile);
            northTile?.ToggleHighlight(true);
            eastTile?.ToggleHighlight(true);
            southTile?.ToggleHighlight(true);
            westTile?.ToggleHighlight(true);
        
        }
    }


    public void DisableUsableTiles() {
        foreach(Tile tile in tiles)
            tile.ToggleHighlight(false);
    }

    public void CreateNewBuilding (BuildingType buildingType, Vector3 position) {
        Building prefabToSpawn = buildingPrefabs.Find(x => x.type == buildingType);
        GameObject buildingObj = Instantiate(prefabToSpawn.gameObject, position, Quaternion.identity);
        buildings.Add(buildingObj.GetComponent<Building>());
        GetTileAtPosition(position).hasBuilding = true;
        DisableUsableTiles();

        GameManager.instance.OnCreatedNewBuilding(prefabToSpawn);
    }

    Tile GetTileAtPosition (Vector3 pos) {
        //Debug.Log("t" + tiles.Count);
        // Debug.Log("gPos" + pos.ToString("F8"));
        // Debug.Log("truePos" + (pos == new Vector3(-0.5f, 1.0f, 0f)));
        //tiles.ForEach(x => Debug.Log("sssss " + (x.transform.position == pos)));
        //tiles.ForEach(x => Debug.Log("splusVec " + (x.transform.position == new Vector3(-0.5f, 1f, 0))));
        //tiles.ForEach(x => Debug.Log("xxxxx " + x.transform.position));
        return tiles.Find(x => x.CanBeHighlighted(pos));

    }

}
