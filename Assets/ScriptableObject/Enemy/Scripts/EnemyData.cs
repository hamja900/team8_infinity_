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
    
    // TODO : Enemy Drop Item
}
