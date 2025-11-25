using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType
{
    Wall = 1,
    Floor = 0
}

public class DungeonGenerator : MonoBehaviour
{
    [Header("Map Size")]
    public int width = 100;
    public int height = 100;

    [Header("Cellular Automata")]
    public int fillPercent = 40;
    public int smoothTimes = 6;

    [Header("Room Cleanup")]
    public int minRoomSize = 50;

    [Header("Tilemap")]
    public Tilemap tilemap;
    public TileBase wallTile;
    public TileBase floorTile;

    public DungeonData map;

    void Awake()
    {
        GenerateDungeon();
    }

    
    public void GenerateDungeon()
    {
        //초기 맵 생성
        int[,] map = CellularAutomata.GenerateRandomMap(width, height, fillPercent);

        //지정된 횟수만큼 스무딩 진행
        for (int i = 0; i < smoothTimes; i++)
            map = CellularAutomata.Smooth(map);

        //형성된 방을 추출
        List<List<Vector2Int>> rooms = RegionFinder.GetRegions(map, TileType.Floor);

        //방의 크기가 지정된 값보다 낮으면 타일을 모두 벽으로 변경
        foreach (List<Vector2Int> room in rooms)
        {
            if (room.Count < minRoomSize)
            {
                foreach (Vector2Int t in room)
                    map[t.x, t.y] = 1;
            }
        }

        //다시 한번 방 추출
        rooms = RegionFinder.GetRegions(map, TileType.Floor);

        //방끼리 통로로 연결
        CorridorConnector.ConnectRooms(map, rooms);

        map = CellularAutomata.Smooth(map);


        //만들어진 맵과 방 정보를 DungeonData로 저장
        this.map = new DungeonData(map, rooms);

        //타일맵에 렌더링
        RenderTilemap();
    }

    private void RenderTilemap()
    {
        tilemap.ClearAllTiles();

        int[,] map = this.map.Map;
        int w = map.GetLength(0);
        int h = map.GetLength(1);

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                TileBase tile = map[x, y] == 1 ? wallTile : floorTile;
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
