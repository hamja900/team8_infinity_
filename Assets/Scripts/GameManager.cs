using System;

public class GameManager : SingletoneBase<GameManager>
{
    public event Action OnEnemyDie;

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
}
