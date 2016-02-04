using UnityEngine;
using System.Collections;

public class AnimSoundScript : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayWalkingSound() {
        audioSource.Play();
    }
}
