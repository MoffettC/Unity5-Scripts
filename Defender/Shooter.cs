using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun; //attaches projectiles to shooting defenders

    private GameObject projectileParent;
    private Animator animator;
    private EnemySpawner myLaneSpawner;

    // Use this for initialization
    void Start() {
        if (GetComponent<Animator>()) {
            animator = GetComponent<Animator>();
            //Debug.Log("Animator gotten");
        } else {
            animator = GetComponentInChildren<Animator>();
            //Debug.Log("Animator gotten in children");
        }

        //Debug.Log(transform.position.y);
        //Finding Projectiles GameObject, if not then create one
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        //print(myLaneSpawner);
    }

    bool FindEnemiesAhead() {
        //Attacker[] enemyArray = GetComponentsInChildren<Attacker>();
        Attacker[] enemyArray = GameObject.FindObjectsOfType<Attacker>();
        //Spriter Animation Integration
        //GameObject[] enemyArray2 = GameObject.FindGameObjectsWithTag("destroyOnWin");

        foreach (Attacker attacker in enemyArray) {
                //if enemy spawner equals positions of shooter/defender
                if (attacker.transform.parent.position.x > transform.parent.position.x) {
                    if (attacker.transform.parent.position.y == transform.parent.position.y) {
                        return true;
                    }
                }           
        }
        //Debug.LogError(name + " cant find spawner in lane");
        return false;
    }

    void SetMyLaneSpawner() { //check all spawners
        //MasterSpawner mSpawner = GameObject.FindObjectOfType<MasterSpawner>();
        //EnemySpawner[] spawnerArray2 = mSpawner.GetComponents<EnemySpawner>();
        EnemySpawner[] spawnerArray = GameObject.FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in spawnerArray) {
            //if enemy spawner equals positions of shooter/defender
            if (spawner.transform.position.y == transform.parent.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane " + transform.position.y);
    }

    private void Fire() {
        //Use animation transition bool as trigger in animation clip
        //!!! Code Firing Sound!!!
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        //childing projectiles to Projectiles GameObject to prevent destruction upon defender death
        newProjectile.transform.parent = projectileParent.transform; 
        //moving projectiles to gun position on defender
        newProjectile.transform.position = gun.transform.position;
    }


	// Update is called once per frame
	void Update () {
        if (FindEnemiesAhead()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
	}

    bool IsAttackerAheadInLane() {
        //child count of myLaneSpawner is the each attacker object being spawned by myLaneSpawner
        if (myLaneSpawner.transform.childCount <= 0) {
           // Debug.LogError(name + " cant find spawner in lane");
            return false;
        } 

        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }
        //if attackers in lane but behind defenders
        return false;
    }

}
