using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Color inactiveColor = Color.black;
	private Color activeColor = Color.white;
	private SpriteRenderer spriteRenderer;
	private Button[] buttonArray;
	private Text costDisplay;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = inactiveColor;
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costDisplay = GetComponentInChildren<Text>();
		costDisplay.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		foreach (Button thisButton in buttonArray) {
			thisButton.spriteRenderer.color = inactiveColor;
		}
		spriteRenderer.color = activeColor;
		selectedDefender = defenderPrefab;
	}
}
