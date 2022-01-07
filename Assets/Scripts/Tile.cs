using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlight;
    public bool hasBuilding;
    public bool isEnabled = false;

    public void ToggleHighlight(bool toggle)
    {
        highlight.SetActive(toggle);
        this.isEnabled = toggle;
    }

    public bool CanBeHighlighted (Vector3 potentialPosition)
    {
        return (transform.position == potentialPosition) && !hasBuilding;
    }

    void OnMouseDown() {
        Debug.Log("DOwn");
        Debug.Log("this.isEnabled" + " " + isEnabled);
        Debug.Log("!hasBuilding" + " " + !hasBuilding);
        Debug.Log("GM.placeBuilding" + " " + GameManager.instance.placingBuilding);
        if( GameManager.instance.placingBuilding && !hasBuilding && isEnabled){
             Debug.Log("True and Down"); 
            Map.instance.CreateNewBuilding(GameManager.instance.curSelectedBuilding, transform.position);
        }
    }
}
