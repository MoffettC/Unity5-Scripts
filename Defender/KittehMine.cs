using UnityEngine;
using System.Collections;

public class KittehMine : MonoBehaviour {

    public float damage = 300f;
    public float explosionRadius = 1f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        Attacker[] obj = GameObject.FindObjectsOfType<Attacker>();
        Transform thisMine = GetComponent<Transform>();

        foreach(Attacker enemy in obj) {
            float distanceToMine = Vector3.Distance(thisMine.position, enemy.transform.position);
            //Debug.Log(distanceToMine + " Distance Vector");
            if (explosionRadius >= distanceToMine) {  
                Health health = enemy.GetComponent<Health>();
                if (health) {
                    health.DealDamage(damage);
                    }
                Debug.Log("Mine Explosion");
                Destroy(gameObject);
            }
        }
    }

}
