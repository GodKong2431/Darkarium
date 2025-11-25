using System.Collections.Generic;
using UnityEngine;

public class DungeonData
{
    public int[,] Map;
    public List<List<Vector2Int>> Rooms;

    public DungeonData(int[,] map, List<List<Vector2Int>> rooms)
    {
        Map = map;
        Rooms = rooms;
    }
}
