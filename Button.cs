using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;
    private Color highlightColor;
    private Image highlightImage;


    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        foreach (Button thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogWarning(name + " has no cost text assigned");
        }
        costText.text = defenderPrefab.GetComponent<Defender>().honeyCost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown() {
        //print(name + " pressed");
        foreach (Button thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
            highlightColor = thisButton.GetComponentInChildren<Image>().color;
            highlightColor.a = 0f;
            thisButton.GetComponentInChildren<Image>().color = highlightColor;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        //highlightImage = GetComponentInChildren<Image>();
        highlightColor = this.GetComponentInChildren<Image>().color;
        highlightColor.a = 255f;
        this.GetComponentInChildren<Image>().color = highlightColor;

        //Passing game object to static script object via mousedown method
        selectedDefender = defenderPrefab;
    }
}
