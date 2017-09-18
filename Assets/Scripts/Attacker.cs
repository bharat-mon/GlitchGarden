using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] public float currentSpeed;

	// Use this for initialization
	void Start () {
		Rigidbody2D thisRigidBody = gameObject.AddComponent<Rigidbody2D>();
		thisRigidBody.isKinematic = true;
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
}
