using UnityEngine;
using System.Collections;

public class SoldatCatAttacker : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
    private float originalSpeed;

    // Use this for initialization
    void Start() {
        if (GetComponent<Animator>()) {
            anim = GetComponent<Animator>();
        } else {
            anim = GetComponentInChildren<Animator>();
        }
        attacker = GetComponent<Attacker>();
        //originalSpeed = 0.3f;
        //attacker.SetSpeed(originalSpeed);
    }
    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D collider) {
        GameObject obj = collider.gameObject;
        //Debug.Log("Original " + originalSpeed);
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
            //Debug.Log("Current " + currentSpeed);
            return;
        }
        anim.SetBool("isSlowDebuff", false);
        anim.SetBool("isFastBuff", false);
        anim.SetBool("isAttacking", true);
        attacker.SetSpeed(0);
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
        attacker.SetSpeed(originalSpeed);
    }
}
