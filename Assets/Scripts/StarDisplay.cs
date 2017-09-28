using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text myText;
	private int starCount = 100;
	public enum Status {SUCCESS, FAILURE};

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
	
	public Status UseStars (int amount) {
		if (starCount >= amount) {
			starCount -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay () {
		myText.text = starCount.ToString();
	}
}
