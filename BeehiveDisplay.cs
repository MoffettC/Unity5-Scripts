using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class BeehiveDisplay : MonoBehaviour {

    private Text beehiveText;
    private int honey = 100;
    public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
        beehiveText = GetComponent<Text>();
        UpdateBeehiveDisplay();
    }
	
    public void AddStars(int amount) {
        //print("Honey added to display");
        honey += amount;
        UpdateBeehiveDisplay();
    }

    public Status UseStars(int amount) {
        if (honey >= amount) {
            honey -= amount;
            UpdateBeehiveDisplay();
            return Status.SUCCESS;
        } else {
            return Status.FAILURE;
        }
    
    }

    void UpdateBeehiveDisplay() {
        //Text component of starText object equal to stars (converted to string)
        beehiveText.text = honey.ToString();
    }
}
