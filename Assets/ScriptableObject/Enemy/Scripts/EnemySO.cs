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

    // Enemy�� �� �� �̵�, ���� Cost
    // ���� ���, 1���� Default ���� 10�̹Ƿ�, enemyMoveCost = 5��� 1�Ͽ� 2ȸ �̵� ����
    public int enemyMoveCost; 
    public int enemyAttackCost;

    // Enemy�� ���� �Ͽ� ���� ������� ���� ���� �ൿ Cost.
    // ���� ���, enemyMoveCost = 7�� ��, ���� �Ͽ��� 10 - 7 = 3��ŭ ���� ���� leftOverTurn�� �����ϱ� ���� �뵵.
    // ���� Enemy�� turn�� ���� turn + leftOverTurn = 13�� �ȴ�.
    public int leftOverTurn;
    
    // TODO : Enemy Drop Item
}

[Serializable]
public struct SetDropTable
{
    public GameObject dropTable;
    [Range(0,1)]public float percent;
}