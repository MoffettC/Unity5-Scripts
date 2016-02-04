using UnityEngine;
using System.Collections;

public class SpeedBuff : MonoBehaviour {

   // private Attacker attacker;
    //public float speedBuff = 1.35f;

    // Use this for initialization
    void Start() {
       // attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    //void OnTriggerStay2D(Collider2D collider) {
    //    GameObject obj = collider.gameObject;
    //    float originalSpeed = obj.GetComponent<Attacker>().currentSpeed;
    //    float newSpeed = originalSpeed * 0.35f;
    //    Debug.Log(newSpeed + " new speed");
    //    bool isAttacking;

    //    if (collider.gameObject.GetComponent<Animator>()) {
    //        Animator objAnim = collider.gameObject.GetComponent<Animator>();
    //        isAttacking = objAnim.GetBool("isAttacking");
    //    } else {
    //        isAttacking = false;
    //    }
        
    //    if (!obj.GetComponent<Attacker>()) { //Checks to see if collision is with Defender
    //        return;
    //    }
    //    if (obj.GetComponent<Attacker>() && !isAttacking) {
    //        obj.GetComponent<Attacker>().currentSpeed = newSpeed;
    //        //Debug.Log(name + " FastBuff " + collider + obj.GetComponent<Attacker>().currentSpeed);
    //    } 

    //    //Debug.Log(name + " colliding with " + collider);
    //}
}
