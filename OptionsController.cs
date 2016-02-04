﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = playerPrefsManager.GetMasterVolume();
        difficultySlider.value = playerPrefsManager.GetDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit() {
        playerPrefsManager.SetMasterVolume(volumeSlider.value);
        playerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01aStart");
    }

    public void SetDefaults() {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
