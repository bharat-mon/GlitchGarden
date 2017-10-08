using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		Vector2 rawPosition = WorldPointTranslator();
		Vector2 spawnPosition = SnapToGrid(rawPosition);
		GameObject defender = Button.selectedDefender;
		int starCost = defender.GetComponent<Defender>().starCost;
		if (starDisplay.UseStars(starCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (spawnPosition, defender);
		} else {
			Debug.Log ("Insufficient stars");
		}
	}

	void SpawnDefender (Vector2 spawnPosition, GameObject defender) {
		GameObject newDefender = Instantiate (defender, spawnPosition, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}
	
	Vector2 WorldPointTranslator () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float cameraDistance = 10f;
		
		Vector2 worldPoint = myCamera.ScreenToWorldPoint(new Vector3 (mouseX, mouseY, cameraDistance));
		return worldPoint;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPoint) {
		float newX = Mathf.RoundToInt(rawWorldPoint.x);
		float newY = Mathf.RoundToInt(rawWorldPoint.y);
		Vector2 snapPosition = new Vector2 (newX, newY);
		return snapPosition;
	}
}
