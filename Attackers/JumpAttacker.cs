using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class JumpAttacker : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D collider) {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponent<Defender>()) { //Checks to see if collision is with Defender
            return;
        }

        if (obj.GetComponent<WallBlock>()) {
            anim.SetTrigger("isJump");
        } else {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
            //Debug.Log(name + " colliding with " + collider);
    }
}
