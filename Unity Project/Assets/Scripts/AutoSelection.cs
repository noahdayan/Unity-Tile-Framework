using UnityEngine;
using System.Collections;

/**
 * This script handles the selection behavior of untamed (robot) units.
 **/

public class AutoSelection : MonoBehaviour {

	private GameObject charManager;
	
	// Use this for initialization
	void Start () {
		charManager = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// check that it is the object's turn to move
		if (CharacterManager.aTurn == 2 || CharacterManager.aTurn == 4)
		{
			// select the object only if it is not selected and no objects are in movement
			if (CharacterManager.aCurrentlySelectedUnit != gameObject && !ClickAndMove.aIsObjectMoving)
			{
				ClickAndMove.aIsObjectMoving = true;	
				CharacterManager.aCurrentlySelectedUnit = gameObject;
				TileManager.aCurrentlySelectedTile = TileManager.pickRandomTile();
				TileManager.aSingleTileIsSelected = true;
				charManager.SendMessage("selectUnit", gameObject);
				charManager.SendMessage("move");
			}
		}
	}
}