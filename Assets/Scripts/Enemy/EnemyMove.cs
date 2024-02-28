using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private EnemyController _controller;

    private void Awake()
    {
        _controller = GetComponent<EnemyController>();
    }

    public void Move()
    {
        Move(_controller.movePoint.position);
    }

    private void Move(Vector3 moveDirection)
    {
        _controller.movePoint.position = moveDirection;
        _controller.transform.position = Vector3.MoveTowards(_controller.transform.position, _controller.movePoint.position, _controller.moveSpeed * Time.deltaTime);

        if (_controller.transform.position.Equals(_controller.movePoint.position))
        {
            _controller.SetEnemyState(EnemyState.Idle);
        }
    }
}
