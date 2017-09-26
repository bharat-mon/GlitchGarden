using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, projectileLauncher;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner mySpawner;

	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		
		animator = GameObject.FindObjectOfType<Animator>();
		
		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()) {
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == this.transform.position.y) {
				mySpawner = spawner;
				return;
			}
		}
		Debug.LogError(name + " can't find spawner in lane");
	}
	
	bool IsAttackerAheadInLane () {
		if (mySpawner.transform.childCount <= 0) {
			return false;
		}
		
		foreach (Transform attacker in mySpawner.transform) {
			if (attacker.transform.position.x >= this.transform.position.x) {
				return true;
			}
		} 
		
		return false;
	}
	
	private void Fire () {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = projectileLauncher.transform.position;
	}
}
