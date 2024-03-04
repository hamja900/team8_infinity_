using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyPathFind : MonoBehaviour
{
    private EnemyController _controller;
    public List<Vector3Int> points = new List<Vector3Int>();

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<EnemyController>();
    }

    public void GetEnemyAroundPositions(Vector3Int pos)
    {
        Vector3Int currentPos = Vector3Int.FloorToInt(_controller.transform.position);
        Vector3Int posLeft = new Vector3Int();
        Vector3Int posRight = new Vector3Int();

        if (currentPos.x == pos.x)
        {
            posLeft.x = pos.x - 1;
            posLeft.y = pos.y;

            posRight.x = pos.x + 1;
            posRight.y = pos.y;
        }
        else if(currentPos.y == pos.y)
        {
            posLeft.y = pos.y - 1;
            posLeft.x = pos.x;

            posRight.y = pos.y + 1;
            posRight.x = pos.x;
        }
        else
        {
            if(currentPos.x > pos.x)
            {
                if(currentPos.y > pos.y)
                {
                    posLeft.x = pos.x;
                    posLeft.y = pos.y + 1;

                    posRight.x = pos.x + 1;
                    posRight.y = pos.y;
                }
                else
                {
                    posLeft.x = pos.x;
                    posLeft.y = pos.y - 1;

                    posRight.x = pos.x + 1;
                    posRight.y = pos.y;
                }
            }
            else
            {
                if (currentPos.y > pos.y)
                {
                    posLeft.x = pos.x - 1;
                    posLeft.y = pos.y;

                    posRight.x = pos.x;
                    posRight.y = pos.y + 1;
                }
                else
                {
                    posLeft.x = pos.x - 1;
                    posLeft.y = pos.y;

                    posRight.x = pos.x;
                    posRight.y = pos.y - 1;
                }
            }
        }
        points.Add(pos);
        points.Add(posLeft);
        points.Add(posRight);
    }

    public Vector3 SetEnemyMovePoint()
    {
        Vector3 movePoint = (_controller.Target.transform.position - transform.position).normalized;

        if (Mathf.Abs(movePoint.x) < 0.5f) movePoint.x = 0f;
        else movePoint.x = movePoint.x > 0 ? 1f : -1f;

        if (Mathf.Abs(movePoint.y) < 0.5f) movePoint.y = 0f;
        else movePoint.y = movePoint.y > 0 ? 1f : -1f;

        movePoint.x += transform.position.x;
        movePoint.y += transform.position.y;

        GetEnemyAroundPositions(Vector3Int.FloorToInt(movePoint));

        return IsTileAvailable();
    }

    private Vector3Int IsTileAvailable()
    {
        foreach(var pos in points)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector3)pos, Vector3.zero, 0.1f, LayerMask.GetMask("Wall", "Enemy", "Player"));
            if(hit.transform == null)
            {
                return pos;
            }
        }

        return Vector3Int.FloorToInt(transform.position);
    }

    public void OnEnemyTurnOver()
    {
        points.Clear();
    }
}
