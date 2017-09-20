using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void DamageDealt (float damage) {
		health -= damage;
		if (health <= 0) {
			DestroyObject();
		}	
	}
	
	// If we add a death animation
	void DestroyObject () {
		Destroy(gameObject);
	}
}
