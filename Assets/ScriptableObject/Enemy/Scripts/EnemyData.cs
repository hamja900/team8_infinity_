using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Enemy_")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public string enemyName;
    public int enemyHealth;
    public int enemyHealthMax;
    public int enemyAtk;
    public float enemyDetectRange;
    public float enemyDropExp;

    // Enemy�� �� �� �̵�, ���� ��
    // ���� ���, 1���� Default ���� 10�̹Ƿ�, enemyMoveFrequency = 5��� 1�Ͽ� 2ȸ �̵� ����
    public int enemyMoveFrequency; 
    public int enemyAttackFrequency;
    // Enemy�� ���� �Ͽ� ���� ������� ���� ���� �ൿ ��.
    // ���� ���, enemyMoveFrequency = 7�� ��, ���� �Ͽ��� 10 - 7 = 3��ŭ ���� ���� leftOverTurn�� �����ϱ� ���� �뵵.
    // ���� Enemy�� turn�� ���� turn + leftOverTurn = 13�� �ȴ�.
    public int leftOverTurn;
    
    // TODO : Enemy Drop Item
}
