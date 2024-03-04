using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : SingletoneBase<TileManager>
{
    public Dictionary<Vector3Int, bool> isObjectOnTile = new Dictionary<Vector3Int, bool>();
    public Tilemap tilemap;
    public Tilemap Wall;
    public Transform Player { get; private set; }

    public List<GameObject> enemyPrefab = new List<GameObject>();

    public event Action OnTilemapInfoSet;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.OnTilemapReady += InitTilemapInfo;

        foreach(var enemy in GameManager.I.enemySO)
        {
            enemyPrefab.Add(enemy.enemyPrefab);
        }
    }

    public void InitTilemapInfo()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        Wall = GameObject.FindGameObjectWithTag("Wall").GetComponent<Tilemap>();

        isObjectOnTile.Clear();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if(!tilemap.HasTile(pos)) continue;

            var tile = tilemap.GetTile(pos);

            isObjectOnTile.Add(pos, false);
            Debug.Log("Init Complete");
        }

        SetTilemapInfo(Vector3Int.FloorToInt(Player.position));
        //OnTilemapInfoSet?.Invoke();
    }

    // 오브젝트 생성, 움직였을 때 현재 자리의 상태를 true로 설정하기
    public void SetTilemapInfo(Vector3Int pos)
    {
        if(isObjectOnTile.ContainsKey(pos))
        {
            isObjectOnTile[pos] = true;
        }
    }

    // 오브젝트가 움직였을 때, 현재 있던 자리의 상태를 false로 변경하기
    public void ReleaceTilemapInfo(Vector3Int pos)
    {
        if (isObjectOnTile.ContainsKey(pos))
        {
            isObjectOnTile[pos] = false;
        }
    }

    public bool HasObjectOnTile(Vector3Int pos)
    {
        if(isObjectOnTile.ContainsKey(pos)) return isObjectOnTile[pos];
        return false;
    }
}
