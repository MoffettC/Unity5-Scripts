using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private BeehiveDisplay beehiveDisplay;
    public int honeyCost = 100;

	// Use this for initialization
	void Start () {
        beehiveDisplay = GameObject.FindObjectOfType<BeehiveDisplay>();
	}

	// Update is called once per frame
	void Update () {	
	}

    public void AddStars(int amount) {
        beehiveDisplay.AddStars(amount);
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log(name + " trigger entered " + col);
    }
}
