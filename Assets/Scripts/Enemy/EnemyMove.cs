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

        // Enemy가 목표 위치까지 이동을 완료했을 시
        if (_controller.transform.position.Equals(_controller.movePoint.position))
        {
            // 상태 전환
            _controller.ExitState(EnemyState.Chasing);
            _controller.SetEnemyState(EnemyState.Idle);
        }
    }
}
