using UnityEngine;
using System.Collections;

public class DefenderDebuffer : MonoBehaviour {

    //public float speedDebuff = 0.3f;
    private float currentSpeed;
    private Attacker attacker;

    // Use this for initialization
    void Start() {
     
    }

    // Update is called once per frame
    void Update() {

    }
    //void OnTriggerEnter2D(Collider2D collider) {
    //    GameObject obj = collider.gameObject;
    //    attacker = collider.gameObject.GetComponent<Attacker>();
    //    currentSpeed = attacker.currentSpeed;

    //    if (!obj.GetComponent<Attacker>()) { //Checks to see if collision is with Attacker
    //        return;
    //    } else {
    //        Debug.Log("Setting Speed Debuff");
    //        attacker.SetSpeed(currentSpeed * speedDebuff);
    //    }
    //}

}
