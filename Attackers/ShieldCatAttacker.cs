using UnityEngine;
using System.Collections;

public class ShieldCatAttacker : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
    private float originalSpeed;
    private Health health;
    private float healthOfChar;
    //private bool withShield = true;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        health = GetComponent<Health>();
        originalSpeed = attacker.currentSpeed;
        anim.SetBool("withShield", true);
    }

    // Update is called once per frame
    void Update () {
        healthOfChar = health.health;
        //Debug.Log(healthOfChar);
        if (healthOfChar < 300) {
            anim.SetBool("withShield", false);
            //Debug.Log("Shield cat below 50");
        }
	}


    void OnTriggerEnter2D(Collider2D collider) {
        GameObject obj = collider.gameObject;
        originalSpeed = attacker.currentSpeed;
        //Checks to see if collision is with Defender
        if (!obj.GetComponent<Defender>() && !obj.GetComponent<SpeedBuff>()) { 
            return;
        }
        if (obj.GetComponent<DefenderDebuffer>()) {
            anim.SetBool("isSlowDebuff", true);
            attacker.currentSpeed = originalSpeed * 0.35f;
            //Debug.Log(name + " SlowBuff " + collider);
            return;
           
        }
        if (obj.GetComponent<SpeedBuff>()) {
            anim.SetBool("isFastBuff", true);
            attacker.currentSpeed = originalSpeed * 1.35f;
            return;
        }
        anim.SetBool("isSlowDebuff", false);
        anim.SetBool("isFastBuff", false);
        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);

        //Debug.Log(name + " colliding with " + collider);
    }

    void OnTriggerExit2D(Collider2D collider) {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<DefenderDebuffer>()) {
            anim.SetBool("isSlowDebuff", false);
            attacker.currentSpeed = originalSpeed;
            //Debug.Log(name + " SlowBuff " + collider);
        }
        if (obj.GetComponent<SpeedBuff>()) {
            anim.SetBool("isFastBuff", false);
            attacker.currentSpeed = originalSpeed;
            Debug.Log(name + " exiting speedBuff " + collider);
        }
    }
}
