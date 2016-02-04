using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between spawns")]
    public float seenEverySec;

    [Range(-1f, 1.5f)] public float currentSpeed;
    public GameObject currentTarget;
    private Animator anim;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.isKinematic = true;
        
        audioSource = GetComponent<AudioSource>();
        if (GetComponent<Animator>()) {
            anim = GetComponent<Animator>();
        } else {
            anim = GetComponentInChildren<Animator>();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            anim.SetBool("isAttacking", false);
            //Debug.Log(name + " is walking " + currentSpeed);
        }
    }

    public void SetSpeed(float speed) {
        //Walking Speed set thru animation clip event
        currentSpeed = speed;
        //Debug.Log("Setting Speed " + currentSpeed);
    }

    void PlayWalkingSound() {
        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D col) {
       // Debug.Log(name + " trigger enter " + col);
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

    public void StrikeCurrentTarget(float damage) {
        //Called from animator at time actual damage done
        if (currentTarget) {
            Debug.Log(name + "caused damaged to " + damage);
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        } 
    }
}
