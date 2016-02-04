using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] attackerArray;
    public GameObject[] spawnPoints;
    public int maxNumbAttackers=10;
    public float yieldTimeMin=1;
    public float yieldTimeMax=10;
    public int secBeforeSpawn;
    public int waitBetweenSpawnCheck;

    private int endOfGame;
    private int randomEnemy;

    // Use this for initialization
    void Awake() {
        this.gameObject.SetActive(false);
    }

    void Start() {
        //this.gameObject.SetActive(false);
        StartCoroutine(Spawn());
    }
    // Update is called once per frame
    void Update() {
        randomEnemy = Random.Range(0, attackerArray.Length);
    }

    IEnumerator Spawn() {
        Debug.Log("Coroutine launched " + this.gameObject);
        yield return new WaitForSeconds(secBeforeSpawn);
        Debug.Log("Finished first wait " + this.gameObject);
        for (int i = 0; i < maxNumbAttackers; i++) {

            yield return new WaitForSeconds(waitBetweenSpawnCheck);
            Debug.Log("Finished spawn wait");

            GameObject thisAttacker = attackerArray[randomEnemy];
            Transform myParent = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;

            if (isTimeToSpawn(thisAttacker)) {
                GameObject myAttacker = Instantiate(thisAttacker) as GameObject;
                myAttacker.transform.parent = myParent;
                myAttacker.transform.position = myParent.transform.position;
                Debug.Log("Spawned Enemy");
                yield return new WaitForSeconds(Random.Range(yieldTimeMin, yieldTimeMax));
                //print(myAttacker);
            } else {
                Debug.Log("Failed To Spawn Enemy");
                i--;
            }
        }
    }

    bool isTimeToSpawn(GameObject attackerGO) {
        if (attackerGO.GetComponentInChildren<Attacker>()) {
            Attacker attacker = attackerGO.GetComponentInChildren<Attacker>();
            float mean = attacker.seenEverySec;
            float threshold = 1 / mean;
            float rnd = Random.value;
            if (rnd < threshold) {
                return true;
            } else {
                return false;
            }
        } else {
            Attacker attacker = attackerGO.GetComponent<Attacker>();
            float mean = attacker.seenEverySec;
            float threshold = 1 / mean;
            float rnd = Random.value;
            if (rnd < threshold) {
                return true;
            } else {
                return false;
            }
        }          
    }




  }

//    public GameObject[] attackerPrefabArray;
//    //new float time;

//	// Use this for initialization
//	void Start () {
//        float time = 1* Time.deltaTime;

//	}

//	// Update is called once per frame
//	void Update () {
//	    foreach (GameObject thisAttacker in attackerPrefabArray) {
//            if (isTimeToSpawn(thisAttacker)) {
//                Spawn(thisAttacker);
//            }
//        }
//	}

//    bool isTimeToSpawn(GameObject attackerGameObject) {
//        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

//        float meanSpawnDelay = attacker.seenEverySec;
//        float spawnsPerSecond = 1 / meanSpawnDelay;

//        if (Time.deltaTime > meanSpawnDelay) {
//            Debug.LogWarning("Spawn rate capped by frame rate");
//        }

//        float threshold = spawnsPerSecond * Time.deltaTime / 5;
//        return (Random.value < threshold);

//    }

//    void Spawn (GameObject myGameObject) {
//        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
//        myAttacker.transform.parent = transform;
//        myAttacker.transform.position = transform.position;
//    }
//}

//-----------------------------------------------------------------------------------
//public class Spawner : MonoBehaviour {

//    private float spawnTime;
//    public GameObject[] attackerArray;
//    private float spawnTimeMax;

//    void Start() {
//        float difficulty = PlayerPrefsManager.GetDifficulty();
//        spawnTimeMax = 25f - (difficulty * (Random.value * 5f));
//        Invoke("NewEnemy", Random.value * 8f);
//    }

//    void SpawnEnemy() {
//        spawnTime = Random.value * spawnTimeMax;
//        Invoke("NewEnemy", spawnTime);
//    }

//    void NewEnemy() {
//        int attackerSelection = Random.Range(0, attackerArray.Length);
//        GameObject newEnemy = Instantiate(attackerArray[attackerSelection], transform.position, Quaternion.identity) as GameObject;
//        newEnemy.transform.parent = transform;
//        SpawnEnemy();
//    }

//}