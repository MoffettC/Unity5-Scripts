using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour {

    public float health = 100f;
    public float armor = 10f;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void DealDamage(float damage) {
        health -= (damage - armor);
        if (health <= 0) {
            //Die Animation
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}
