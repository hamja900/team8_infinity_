using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnEnemyDie;
    public event Action OnTilemapReady;
    public event Action OnEnemyPrefabReady;

    public int clearRoomNum = 1;



    public List<GameObject> EnemyPrefab = new List<GameObject>();

    public List<GameObject> normalEnemyPrefab = new List<GameObject>();
    public List<GameObject> bossEnemyPrefab = new List<GameObject>();

    public List<GameObject> RandomEnemyPrefab = new List<GameObject>();

    public List<GameObject> CurrentEnemyList = new List<GameObject>();
    public List<GameObject> ItemList = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        DataManager.I.JsonLoad();
        SetEnemyPrefabList();
        MakeRandomEnemyList();
    }

    public void EnemyDeadAnimationEnd()
    {
        OnEnemyDie?.Invoke();
    }

    public void TilemapReady()
    {
        OnTilemapReady?.Invoke();
    }

    public void SetEnemyPrefabList()
    {
        foreach(var go in Resources.LoadAll<GameObject>("Enemy"))
        {
            EnemyPrefab.Add(go);
        }
        EnemyPrefabList();
    }

    public void MakeRandomEnemyList()
    {
        RandomEnemyPrefab.Clear();

        foreach (var go in normalEnemyPrefab)
        {
            if (go != null)
            {
                int enemyAmount = UnityEngine.Random.Range(1, 3);
                for (int i = 0; i < enemyAmount; i++)
                {
                    RandomEnemyPrefab.Add(go);
                }
            }
        }
        foreach (var go in RandomEnemyPrefab)
        {
            Debug.Log(go.name.ToString());
        }
        OnEnemyPrefabReady?.Invoke();
    }

    public void EnemyPrefabList()
    {
        foreach (var enemy in EnemyPrefab)
        {
            if (enemy.gameObject.GetComponent<EnemyController>().EnemyData.enemyType == EnemyType.Normal)
                normalEnemyPrefab.Add(enemy);
            else
                bossEnemyPrefab.Add(enemy);
        }
    }

    public void FindAllEnemy()
    {
        foreach(var go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            CurrentEnemyList.Add(go);
        }
    }

    public void ReleaseAllEnemy()
    {
        foreach(var go in CurrentEnemyList)
        {
            if (go == null) continue;
            go.GetComponent<EnemyController>().ReleaseEnemyTurn();
            Destroy(go);
        }
        CurrentEnemyList.Clear();
    }
    public void DestroyItem()
    {
        foreach (var item in ItemList)
        {
            Destroy(item.gameObject);
        }
    }
}
