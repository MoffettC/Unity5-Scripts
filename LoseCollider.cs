using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        //FindObjectOfType to find the one GameObject when you only have one
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Lose Collider");
        levelManager.LoadLevel("Lose"); //Remember to change ingame level if you change name!
    }
}
