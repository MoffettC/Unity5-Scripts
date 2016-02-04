using UnityEngine;
using System.Collections;

public class MS01 : MonoBehaviour {

    public GameObject[] spawnPoints;

    private LevelSlider levelSlider;
    private float currentTime;
    private float endOfLevel;
    private bool check = true;
    private bool check2 = true;

    // Use this for initialization
    void Start() {
        levelSlider = GameObject.FindObjectOfType<LevelSlider>();
        endOfLevel = levelSlider.levelTimeSec;
    }

    void TurnOffSpawns() {
        foreach (GameObject child in spawnPoints) {
            child.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeScale == 1.0f) {
            currentTime = Time.timeSinceLevelLoad;
        }
        //Debug.Log(currentTime);
        SpawnActivateChecker();
        if (currentTime >= endOfLevel) {
            NoMoreSpawning();
        }
    }

    void SpawnActivateChecker() {
        if ((currentTime >= 1f) && (check == true)) {
            InitialSpawning();
            //Debug.Log("Initial Spawn");
            check = false;
        }
        if ((currentTime >= 40f) && (check2 == true)) {
            LastWaveSpawn();
            // Debug.Log("LAST Spawn");
            check2 = false;
        }
    }

    void InitialSpawning() {
        foreach (GameObject child in spawnPoints) {
            child.SetActive(true);
            EnemySpawner eSpawn = child.GetComponentInChildren<EnemySpawner>();
            eSpawn.maxNumbAttackers = 15;
            eSpawn.secBeforeSpawn = 20;
            eSpawn.yieldTimeMax = 15;
            eSpawn.yieldTimeMin = 10;
            eSpawn.waitBetweenSpawnCheck = 3;
            Debug.Log("Initial Spawn Launch");
        }

    }

    void LastWaveSpawn() {
        foreach (GameObject child in spawnPoints) {
            child.SetActive(true);
            EnemySpawner eSpawn = child.GetComponentInChildren<EnemySpawner>();
            eSpawn.maxNumbAttackers = 10;
            eSpawn.secBeforeSpawn = 0;
            eSpawn.yieldTimeMax = 5;
            eSpawn.yieldTimeMin = 2;
            eSpawn.waitBetweenSpawnCheck = 1;
            Debug.Log("Last Spawn Launch");
        }
    }

    void NoMoreSpawning() {
        foreach (GameObject child in spawnPoints) {
            EnemySpawner eSpawn = child.GetComponentInChildren<EnemySpawner>();
            eSpawn.maxNumbAttackers = 0;
            eSpawn.secBeforeSpawn = 100;
            eSpawn.yieldTimeMax = 100;
            eSpawn.yieldTimeMin = 200;
            eSpawn.waitBetweenSpawnCheck = 100;
            Debug.Log("Turning off Spawning");
        }
    }
}
