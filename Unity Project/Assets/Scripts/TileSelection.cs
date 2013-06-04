using UnityEngine;
using System.Collections;

public class TileSelection : MonoBehaviour {
	
	private GameObject tileManager;
	
	// Use this for initialization
	void Start () {
		tileManager = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown()
	{
			// select the tile and move the currently selected unit towards it.
			if (TileManager.aCurrentlySelectedTile != gameObject && !CharacterManager.aMidTurn)
			{
				if (CharacterManager.aSingleUnitIsSelected && !ClickAndMove.aIsObjectMoving)
				{
					tileManager.SendMessage("selectTile", gameObject);
					tileManager.SendMessage("move");
					//Removing Mana for the move action.
					CharacterManager.aCurrentlySelectedUnit.SendMessage("RemoveMoveMana");
					
					//ActionMenuGUI.activateMvmtMenu = true;
				}
			}
			
			// de-select the tile, but only if the unit is not moving towards it
			else if (TileManager.aCurrentlySelectedTile == gameObject && !CharacterManager.aMidTurn)
			{
				if (!CharacterManager.aSingleUnitIsSelected)
				{
					tileManager.SendMessage("deselct");
				}
			}
	}

}
