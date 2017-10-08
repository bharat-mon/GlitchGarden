using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelTime = 100;
	
	private LevelManager levelManager;
	private AudioSource audioSource;
	private Slider slider;
	private bool islevelComplete = true;

	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelTime;
		if (Time.timeSinceLevelLoad >= levelTime && islevelComplete) {
			audioSource.Play();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			islevelComplete = false;
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadLevel("Win");
	}
}
