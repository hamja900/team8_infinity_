using System.Collections;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyController _controller;
    public Animator Animator { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<EnemyController>();
        Animator = GetComponentInChildren<Animator>();
    }

    public void ToggleAnimation(string animationName, bool toggle)
    {
        Animator.SetBool(animationName, toggle);
    }

    public void PlayAttackAnimation()
    {
        StartCoroutine("PlayAttack");
    }

    IEnumerator PlayAttack()
    {
        Animator.SetTrigger("EnemyAttack");

        while (true)
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
