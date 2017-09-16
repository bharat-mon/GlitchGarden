using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] public float moveSpeed;

	// Use this for initialization
	void Start () {
		Rigidbody2D thisRigidBody = gameObject.AddComponent<Rigidbody2D>();
		thisRigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D () {
		Debug.Log(name + "enter trigger");
	}
}
