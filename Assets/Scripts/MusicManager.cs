using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusic;
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnLevelWasLoaded(int level) {
		if(levelMusic[level]) {
			audioSource.clip = levelMusic[level];
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}
