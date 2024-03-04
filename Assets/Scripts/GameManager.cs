using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnEnemyDie;
    public event Action OnTilemapReady;

    public int clearRoomNum = 0;



    public List<EnemySO> enemySO = new List<EnemySO>();

    // Start is called before the first frame update
    void Start()
    {
        DataManager.I.JsonLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeadAnimationEnd()
    {
        OnEnemyDie?.Invoke();
    }

    public void TilemapReady()
    {
        OnTilemapReady?.Invoke();
        TileManager.I.InitTilemapInfo();
    }
}
