using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	private GameObject attacker;
	private Health health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		attacker = collider.gameObject;
		if (attacker.GetComponent<Attacker>()) {
			health = attacker.GetComponent<Health>();
			health.DamageDealt(damage);
			Destroy(gameObject);
		}
	}
}
