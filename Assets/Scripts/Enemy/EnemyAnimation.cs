using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyController _controller;
    public Animator Animator { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<EnemyController>();
        Animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation(int animationHash)
    {

    }

    public void StopAnimation(int animationHash)
    {

    }
}
