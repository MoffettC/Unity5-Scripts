using UnityEngine;
using System.Collections;

public class RifleBullet: MonoBehaviour {

    public float speed, damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //Debug.Log("Projectile Move");
	}

    void OnTriggerEnter2D (Collider2D col) {
        //Dodge Mechanic
        Attacker attacker = col.gameObject.GetComponent<Attacker>();
        Health health = col.gameObject.GetComponent<Health>();
        Shield shield = col.gameObject.GetComponent<Shield>();

        //Debug.Log(name + " attacked " + col);
        if (shield) {
            shield.DealDamage(damage);
            //Debug.Log("Shield Damaged");
            Destroy(gameObject);
        }
        else if (attacker && health) {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
