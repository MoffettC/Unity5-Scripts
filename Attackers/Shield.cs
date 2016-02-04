using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public float shieldStrength = 50f;

    // Use this for initialization
    void Start () {
       // shield = GetComponent<Shield>;
    }

    public void DealDamage(float damage) {
        shieldStrength -= damage;
        if (shieldStrength <= 0) {
            //Die Animation
            //Debug.Log("Shield Destroyed");
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
