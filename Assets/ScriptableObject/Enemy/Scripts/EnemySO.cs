using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy_")]
public class EnemySO : ScriptableObject
{
    public GameObject enemyPrefab;
    public string enemyName;
    public int enemyHealth;
    public int enemyMaxHealth;
    public int enemyAtk;
    public float enemyAttackRange;
    public float enemyDetectRange;
    public float enemySafeRange;
    public float enemyDropExp;
    public SetDropTable[] dropTable;

    // Enemy의 턴 당 이동, 공격 Cost
    // 예를 들어, 1턴의 Default 값은 10이므로, enemyMoveCost = 5라면 1턴에 2회 이동 가능
    public int enemyMoveCost; 
    public int enemyAttackCost;

    // Enemy의 이전 턴에 마저 사용하지 못한 남은 행동 Cost.
    // 예를 들어, enemyMoveCost = 7일 때, 이전 턴에서 10 - 7 = 3만큼 남은 것을 leftOverTurn에 저장하기 위한 용도.
    // 다음 Enemy의 turn의 값은 turn + leftOverTurn = 13이 된다.
    public int leftOverTurn;
    
    // TODO : Enemy Drop Item
}

[Serializable]
public struct SetDropTable
{
    public GameObject dropTable;
    [Range(0,1)]public float percent;
}