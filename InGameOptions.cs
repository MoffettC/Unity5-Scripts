using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameOptions: MonoBehaviour {

    static bool pauseVisible;
    GameObject tutorialPanel;
	// Use this for initialization

	void Start () {
        foreach (GameObject tutorialPan in GameObject.FindGameObjectsWithTag("TutorialPanel")) {
            if (tutorialPan.name == "TutorialPanel") {
                tutorialPanel = tutorialPan;
            }
        }
        pauseVisible = true;
        Time.timeScale = 0;
        //DisplayTutorial();
    }
	

    public void Pause() {
            if (pauseVisible) {
                pauseVisible = false;
                Time.timeScale = 1.0f;
 
            } else {
                pauseVisible = true;
                Time.timeScale = 0.0f;
            }       
    }

    public void DisplayTutorial() {
        Pause();
        DestroyObject(tutorialPanel);
    }
}
