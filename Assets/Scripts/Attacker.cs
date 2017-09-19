using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D () {
		Debug.Log(name + "enter trigger");
	}
	
	public void SetMoveSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget (float damage) {
		Debug.Log(name + " dealt " + damage + " damage");
	}
	
	public void Attack (GameObject defender) {
		currentTarget = defender;
		Debug.Log(currentTarget);
	}
}
