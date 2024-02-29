using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnDeadAnimationFinish()
    {
        GameManager.I.EnemyDeadAnimationEnd();
    }
}
