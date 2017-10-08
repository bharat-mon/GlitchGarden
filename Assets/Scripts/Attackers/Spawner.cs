using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerArray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerArray) {
			if (isTimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn (GameObject myGameObject) {
		GameObject thisAttacker = Instantiate(myGameObject) as GameObject;
		thisAttacker.transform.parent = this.transform;
		thisAttacker.transform.position = this.transform.position;
	}
	
	bool isTimeToSpawn (GameObject attacker) {
		Attacker thisAttacker = attacker.GetComponent<Attacker>();
		
		float meanSpawnDelay = thisAttacker.spawnRate;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		float spawnTreshold = spawnsPerSecond * Time.deltaTime / 5;
		
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		return (Random.value < spawnTreshold);
	}
}
