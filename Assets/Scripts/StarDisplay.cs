using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text myText;
	private int starCount = 0;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = starCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars (int amount) {
		starCount += amount;
		UpdateDisplay();
	}
	
	public void UseStars (int amount) {
		starCount -= amount;
		UpdateDisplay();
	}
	
	private void UpdateDisplay () {
		myText.text = starCount.ToString();
	}
}
