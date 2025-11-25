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
    [SerializeField] private int _width = 100;
    [SerializeField] private int _height = 100;

    [Header("Cellular Automata")]
    [SerializeField] private int _fillPercent;
    [SerializeField] private int _smoothTimes;

    [Header("Room Cleanup")]
    [SerializeField] private int _minRoomSize;

    [Header("Tilemap")]
    [SerializeField] private Tilemap _wallTileMap;
    [SerializeField] private Tilemap _floorTileMap;
    [SerializeField] private TileBase _wallTile;
    [SerializeField] private TileBase _floorTile;

    public DungeonData map;

    void Awake()
    {
        GenerateDungeon();
    }

    
    public void GenerateDungeon()
    {
        //초기 맵 생성
        int[,] map = CellularAutomata.GenerateRandomMap(_width, _height, _fillPercent);

        //지정된 횟수만큼 스무딩 진행
        for (int i = 0; i < _smoothTimes; i++)
            map = CellularAutomata.Smooth(map);

        //형성된 방을 추출
        List<List<Vector2Int>> rooms = RegionFinder.GetRegions(map, TileType.Floor);

        //방의 크기가 지정된 값보다 낮으면 타일을 모두 벽으로 변경
        foreach (List<Vector2Int> room in rooms)
        {
            if (room.Count < _minRoomSize)
            {
                foreach (Vector2Int t in room)
                    map[t.x, t.y] = 1;
            }
        }

        //다시 한번 방 추출
        rooms = RegionFinder.GetRegions(map, TileType.Floor);

        //방끼리 통로로 연결
        CorridorConnector.ConnectRooms(map, rooms);

        //마지막 스무딩
        for(int i = 0; i < 5; i++)
            map = CellularAutomata.Smooth(map);


        //만들어진 맵과 방 정보를 DungeonData로 저장
        this.map = new DungeonData(map, rooms);

        //타일맵에 렌더링
        RenderTilemap();
    }

    private void RenderTilemap()
    {
        _wallTileMap.ClearAllTiles();
        _floorTileMap.ClearAllTiles();

        int[,] map = this.map.Map;
        int w = map.GetLength(0);
        int h = map.GetLength(1);

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                if(map[x, y] == 0)
                {
                    _floorTileMap.SetTile(new Vector3Int(x, y, 0), _floorTile);
                }
                if(map[x, y] == 1)
                {
                    _wallTileMap.SetTile(new Vector3Int(x, y, 0), _wallTile);
                }
                //TileBase tile = map[x, y] == 1 ? _wallTile : _floorTile;
                //_wallTileMap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
}
