using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Wandering,
    Attacking,
    Dead
}

public class EnemyController : MonoBehaviour, IDamageable
{
    public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {

    }
}
