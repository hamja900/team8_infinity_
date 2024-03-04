using System;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnEnemyDie;
    public event Action OnTilemapReady;

    // Start is called before the first frame update
    void Start()
    {
        
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
