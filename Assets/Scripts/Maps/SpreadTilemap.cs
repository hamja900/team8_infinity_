using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadTilemap : MonoBehaviour
{
    // TileBase를 Tilemap에 깐다고 생각하자
    // 바닥or벽을 타일맵에 까는역활수행
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap wall;
    // 사용할 타일 에셋
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;

    //HashSet 검색
    public void SpreadFloorTilemap(HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, floor, floorTile);
    }

    public void SpreadWallTilemap(HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, wall, wallTile);
    }

    // 파라미터로 받은 포지션에 있는 좌표들에 타일을 까는 함수
    private void SpreadTile(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(var position in positions)
        {
            tilemap.SetTile((Vector3Int)position, tile);
        }
    }

    // 타일맵에 이미 깔려있는 모든 타일들을 제거
    public void ClearAllTiles()
    {
        floor.ClearAllTiles();
        wall.ClearAllTiles();
    }
}
