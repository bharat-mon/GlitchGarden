using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Attacker spawn rate in seconds")]
	public float spawnRate;

	private float currentSpeed;
	private GameObject currentTarget;
	private Health health;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		Debug.Log(name + "enter trigger");
	}
	
	public void SetMoveSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void Attack (GameObject defender) {
		currentTarget = defender;
		Debug.Log(currentTarget);
	}
	
	public void StrikeCurrentTarget (float damage) {
		Debug.Log(name + " dealt " + damage + " damage");
		if (currentTarget) {
			health = currentTarget.GetComponent<Health>();
			health.DamageDealt(damage);
		}
	}
}
