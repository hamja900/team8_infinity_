using System;
using System.IO;
using UnityEngine;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnEnemyDie;
    


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
}
