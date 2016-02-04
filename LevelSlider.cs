using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour {

    private Slider slider;
    private AudioSource audioSource;
    private bool endOfLevel = false;
    private LevelManager levelManager;
    private GameObject winText;

    public float levelTimeSec;
    
	// Use this for initialization
	void Start () {
        levelTimeSec = 100f;
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winText = GameObject.Find("WinText");
        if (!winText) {
            Debug.LogWarning("No Win Text");
        }
        winText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        this.slider.value = Time.timeSinceLevelLoad / levelTimeSec;
        
        if (Time.timeSinceLevelLoad >= levelTimeSec && !endOfLevel) {
            EndOfLevel();
        }
    }

    private void EndOfLevel() {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winText.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        endOfLevel = true;
    }

    void DestroyAllTaggedObjects() {
        GameObject[] unitToDestroy = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject taggedObject in unitToDestroy) {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}
