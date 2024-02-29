using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : SingletoneBase<TileManager>
{
    public Dictionary<Vector3Int, bool> isObjectOnTile = new Dictionary<Vector3Int, bool>();
    public Tilemap tilemap;
    public Transform Player {  get; private set; }

    public event Action OnTilemapInfoSet;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.OnTilemapReady += InitTilemapInfo;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitTilemapInfo()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").gameObject.GetComponent<Tilemap>();
        isObjectOnTile.Clear();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if(!tilemap.HasTile(pos)) continue;

            var tile = tilemap.GetTile(pos);

            isObjectOnTile.Add(pos, false);
            Debug.Log("Init Complete");
        }

        SetTilemapInfo(Vector3Int.FloorToInt(Player.transform.position));
        //OnTilemapInfoSet?.Invoke();
    }

    public void SetTilemapInfo(Vector3Int pos)
    {
        if(isObjectOnTile.ContainsKey(pos))
        {
            isObjectOnTile[pos] = true;
        }
    }

    public bool HasObjectOnTile(Vector3Int pos)
    {
        if(isObjectOnTile.ContainsKey(pos)) return isObjectOnTile[pos];
        return false;
    }
}
