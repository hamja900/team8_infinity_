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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleAnimation(string animationName, bool toggle)
    {
        Animator.SetBool(animationName, toggle);
    }
}
