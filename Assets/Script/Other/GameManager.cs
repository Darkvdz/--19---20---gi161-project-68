using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int MonsterDeadCount = 0;  
    public int MonsterToKill = 15;
    public int MaxConcurrentMonsters = 5;

    public List<GameObject> MonsterPrefab = new List<GameObject>();
    public List<GameObject> BossPrefab = new List<GameObject>();

    public int BossDeadCount = 0;
    public int BossToKill = 1;

    public int numberOfBoss;


    public bool CompleteLv1 = false;
    public bool CompleteLv2 = false;
    public bool CompleteLv3 = false;

    public GameObject WarpPointLv1;
    public GameObject WarpPointLv2;
    public GameObject WarpPointLv3;

    public Transform spawnPointLv1;
    public Transform spawnPointLv2;
    public Transform spawnPointLv3;

    public Transform monsterSpawnPointLv1;
    public Transform monsterSpawnPointLv2;
    public Transform monsterSpawnPointLv3;

    private Transform monsterSpawn;

    private List<GameObject> spawnedMonsters = new List<GameObject>();

    private bool onLastLevel = false;

    private int currentLevel = 1;

    private void Awake()
    {
        Instance = this;

        if (WarpPointLv1 != null)
            WarpPointLv1.SetActive(false);
        if (WarpPointLv2 != null)
            WarpPointLv2.SetActive(false);

        StartLevel1();
    }

    public void nextLevel() 
    {
        currentLevel += 1;
        if (currentLevel == 2) 
        {
            StartLevel2();
        }
        else if (currentLevel == 3)
        {
            StartLevel3();
        }
        else if (currentLevel >= 4)
        {
            CompleteGame();
        }

    }


    public void StartLevel1()
    {
        MonsterDeadCount = 0;
        BossDeadCount = 0;
        MonsterToKill = 7;
        numberOfBoss = 0;

        spawnedMonsters.Clear();

        monsterSpawn = monsterSpawnPointLv1;

        StartCoroutine(SpawnMonstersCoroutine());
    }

    public void StartLevel2()
    {
        MonsterDeadCount = 0;
        BossDeadCount = 0;
        MonsterToKill = 15;
        numberOfBoss = 1;

        spawnedMonsters.Clear();

        monsterSpawn = monsterSpawnPointLv2;

        StartCoroutine(SpawnMonstersCoroutine());
    }

    public void StartLevel3()
    {
        MonsterDeadCount = 0;
        BossDeadCount = 0;
        MonsterToKill = 20;
        numberOfBoss = 0;

        spawnedMonsters.Clear();

        monsterSpawn = monsterSpawnPointLv3;

        StartCoroutine(SpawnMonstersCoroutine());
    }


    private IEnumerator SpawnMonstersCoroutine()
    {
        while (MonsterDeadCount < MonsterToKill)
        {
            // ถ้า spawnedMonsters ยังไม่เต็ม MaxConcurrentMonsters และรวมกับตัวตายยังไม่เกิน MonsterToKill
            print("1" + (MonsterDeadCount + spawnedMonsters.Count < MonsterToKill));
            print("MonsterDeadCount" + MonsterDeadCount);
            print("spawnedMonsters" + spawnedMonsters.Count);
            print("MonsterToKill" + MonsterToKill);

            if (spawnedMonsters.Count < MaxConcurrentMonsters &&
                MonsterDeadCount + spawnedMonsters.Count < MonsterToKill)
            {
                int randomIndex = Random.Range(0, MonsterPrefab.Count);
                GameObject monster = Instantiate(MonsterPrefab[randomIndex], monsterSpawn.position, Quaternion.identity);
                spawnedMonsters.Add(monster);

                yield return new WaitForSeconds(2f); // delay ต่อการ spawn 1 ตัว
            }
            else
            {
                yield return null; // รอ frame ถัดไปแล้วตรวจสอบใหม่
            }
        }

        // ครบ 15 ตัวแล้ว spawn บอส
        SpawnBoss();
        if (onLastLevel) 
        {
            SpawnBoss();
        }
        numberOfBoss = 0;
    }

    private void SpawnBoss()
    {
        if (monsterSpawn)
        {
            Instantiate(BossPrefab[numberOfBoss], monsterSpawn.position, Quaternion.identity);
            numberOfBoss += 1;
        }
    }


    public void MonsterKilled(GameObject monster)
    {

        if (spawnedMonsters.Contains(monster))
            spawnedMonsters.Remove(monster);
            //print("delete");

        //print("in");
        MonsterDeadCount++;

    }

    public void BossKilled()
    {
        BossDeadCount++;
        print(BossDeadCount);
        if (BossDeadCount >= BossToKill)
        {
            print("complete");
            CompleteLv1 = true;
            if (WarpPointLv1 != null)
                WarpPointLv1.SetActive(true);  // แสดงวาป
        }
    }

    public void CompleteGame() 
    {
        print("end game");
    }


}
