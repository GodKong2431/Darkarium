using System.Collections.Generic;
using UnityEngine;

public static class CorridorConnector
{
    /// <summary>
    /// 밤의 중앙을 구하고 순차적으로 1 -> 2 -> 3 순으로 방을 연결하는 메서드
    /// </summary>
    /// <param name="map">맵</param>
    /// <param name="rooms">형성된 방</param>
    public static void ConnectRooms(int[,] map, List<List<Vector2Int>> rooms)
    {
        //방이 하나하면 종료
        if (rooms.Count <= 1) return;

        //각 방의 중심 좌표들을 저장할 리스트
        List<Vector2Int> centers = new();

        //각 방의 중심 좌표 계산 및 저장
        foreach (var room in rooms)
            centers.Add(GetCenter(room));

        //중심 좌표들을 순차적으로 연결
        for (int i = 0; i < centers.Count - 1; i++)
            CarvePath(map, centers[i], centers[i + 1], 3);
    }

    /// <summary>
    /// 방의 줌심 좌표를 구하는 메서드
    /// </summary>
    /// <param name="room">방 하나</param>
    /// <returns>중심 좌표</returns>
    private static Vector2Int GetCenter(List<Vector2Int> room)
    {
        //방 좌표들의 평균 값 계산
        int x = 0, y = 0;
        foreach (var t in room)
        {
            x += t.x; 
            y += t.y;
        }
        //평균 좌표 반환
        return new Vector2Int(x / room.Count, y / room.Count);
    }

    /// <summary>
    /// 방의 줌심끼리 이은 통로를 만드는 메서드
    /// </summary>
    /// <param name="map">맵</param>
    /// <param name="from">통로 시작점</param>
    /// <param name="to">통로 끝점</param>
    /// <param name="width">통로 너비</param>
    private static void CarvePath(int[,] map, Vector2Int from, Vector2Int to, int width = 1)
    {
        //시작 좌표 저장
        int x = from.x;
        int y = from.y;

        //x좌표를 목표 지점까지 이동하여 통로 생성
        while (x != to.x)
        {
            CarveTileWithWidth(map, x, y, width);
            x += x < to.x ? 1 : -1;
        }

        //y좌표를 목표 지점까지 이동하여 통로 생성
        while (y != to.y)
        {
            CarveTileWithWidth(map, x, y, width);
            y += y < to.y ? 1 : -1;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="map">맵</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width">통로의 너비</param>
    private static void CarveTileWithWidth(int[,] map, int x, int y, int width)
    {
        //너비의 절반 계산
        int half = width / 2;

        //지정된 너비만큼 주변칸을 바닥으로 변경
        for (int dx = -half; dx <= half; dx++)
        {
            for (int dy = -half; dy <= half; dy++)
            {
                //새 좌표 계산
                int nx = x + dx;
                int ny = y + dy;

                //맵 범위 내에 있는지 확인
                if (nx >= 0 && ny >= 0 && nx < map.GetLength(0) && ny < map.GetLength(1))
                {
                    map[nx, ny] = 0;
                }
            }
        }
    }
}
