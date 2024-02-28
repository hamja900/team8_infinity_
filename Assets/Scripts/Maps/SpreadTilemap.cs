using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadTilemap : MonoBehaviour
{
    // TileBase�� Tilemap�� ��ٰ� ��������
    // �ٴ�or���� Ÿ�ϸʿ� ��¿�Ȱ����
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap wall;
    // ����� Ÿ�� ����
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;

    //HashSet �˻�
    public void SpreadFloorTilemap(HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, floor, floorTile);
    }

    public void SpreadWallTilemap(HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, wall, wallTile);
    }

    // �Ķ���ͷ� ���� �����ǿ� �ִ� ��ǥ�鿡 Ÿ���� ��� �Լ�
    private void SpreadTile(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(var position in positions)
        {
            tilemap.SetTile((Vector3Int)position, tile);
        }
    }

    // Ÿ�ϸʿ� �̹� ����ִ� ��� Ÿ�ϵ��� ����
    public void ClearAllTiles()
    {
        floor.ClearAllTiles();
        wall.ClearAllTiles();
    }
}
