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
        if (_controller.movePoint.position == transform.position)
        {
            _controller.ExitState(EnemyState.Chasing);
            _controller.SetEnemyState(EnemyState.Idle);
            return;
        }

        Move(_controller.movePoint.position);
    }

    private void Move(Vector3 moveDirection)
    {
        TileManager.I.ReleaceTilemapInfo(Vector3Int.FloorToInt(_controller.transform.position));
        _controller.movePoint.position = moveDirection;
        _controller.transform.position = Vector3.MoveTowards(_controller.transform.position, _controller.movePoint.position, _controller.moveSpeed * Time.deltaTime);

        // Enemy�� ��ǥ ��ġ���� �̵��� �Ϸ����� ��
        if (_controller.transform.position.Equals(_controller.movePoint.position))
        {
            TileManager.I.SetTilemapInfo(Vector3Int.FloorToInt(_controller.transform.position));

            // ���� ��ȯ
            _controller.ExitState(EnemyState.Chasing);
            _controller.SetEnemyState(EnemyState.Idle);
        }
    }
}
