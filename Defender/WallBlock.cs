using UnityEngine;
using System.Collections;

public class WallBlock : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col) {
        Attacker attacker = col.gameObject.GetComponent<Attacker>();

        if (attacker) {
            animator.SetTrigger("underAttackTrigger");
        }
    }
}
