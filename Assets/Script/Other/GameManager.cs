using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Hero Settings")] 
    public GameObject[] heroPrefabs; 

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
        
        SpawnHero();

        if (WarpPointLv1 != null)
            WarpPointLv1.SetActive(false);
        if (WarpPointLv2 != null)
            WarpPointLv2.SetActive(false);
        if (WarpPointLv3 != null)
            WarpPointLv3.SetActive(false);

        StartLevel1();
    }
    
    void SpawnHero()
    {
        // อ่านค่าที่ส่งมาจากหน้าเมนู (ถ้าไม่มีจะใช้ 0 คือ Maskman)
        int selectedID = PlayerPrefs.GetInt("SelectedHero", 0);

        // เช็คว่ามีข้อมูล Prefab ครบไหม และจุดเกิด Lv1 มีไหม
        if (heroPrefabs.Length > selectedID && spawnPointLv1 != null)
        {
            // เสกตัวละครตาม ID ที่จุดเกิด Level 1
            Instantiate(heroPrefabs[selectedID], spawnPointLv1.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Error: ลืมใส่ Hero Prefab หรือลืมใส่ SpawnPointLv1 ครับ!");
        }
    }

    public void nextLevel() 
    {
        currentLevel += 1;

        print(currentLevel);

        if (currentLevel == 2) 
        {
            CompleteLv1 = true;
            StartLevel2();
        }
        else if (currentLevel == 3)
        {
            onLastLevel = true;
            CompleteLv2 = true;
            StartLevel3();
        }
        else if (currentLevel >= 4)
        {
            CompleteLv3 = true;
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

        MonsterToKill = 15;
        numberOfBoss = 1;

        spawnedMonsters.Clear();

        monsterSpawn = monsterSpawnPointLv2;

        StartCoroutine(SpawnMonstersCoroutine());
    }

    public void StartLevel3()
    {
        MonsterDeadCount = 0;

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
            

            if (spawnedMonsters.Count < MaxConcurrentMonsters &&
                MonsterDeadCount + spawnedMonsters.Count < MonsterToKill)
            {
                int randomIndex = Random.Range(0, MonsterPrefab.Count);
                GameObject monster = Instantiate(MonsterPrefab[randomIndex], monsterSpawn.position, Quaternion.identity);
                spawnedMonsters.Add(monster);

                yield return new WaitForSeconds(1f); // delay ��͡�� spawn 1 ���
            }
            else
            {
                yield return null; // �� frame �Ѵ����ǵ�Ǩ�ͺ����
            }
        }

        
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
            if(BossDeadCount == 1) 
            {
                if (WarpPointLv1 != null)
                    WarpPointLv1.SetActive(true);  // �ʴ��һ
            }
            else if (BossDeadCount == 2)
            {
                if (WarpPointLv2 != null)
                    WarpPointLv2.SetActive(true);  // �ʴ��һ
            }
            else if (BossDeadCount >= 4)
            {
                if (WarpPointLv3 != null)
                    WarpPointLv3.SetActive(true);  // �ʴ��һ
            }

        }
    }

    public void CompleteGame() 
    {
        print("end game");
    }


}
