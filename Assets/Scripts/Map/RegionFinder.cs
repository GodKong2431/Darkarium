using System.Collections.Generic;
using UnityEngine;

public static class RegionFinder
{
    private static List<Vector2Int> Directions = new()
    {
        new Vector2Int(1,0), new Vector2Int(-1,0),
        new Vector2Int(0,1), new Vector2Int(0,-1)
    };

    /// <summary>
    /// 형성된 방을 찾아오는 메서드
    /// </summary>
    /// <param name="map">스무딩 진행된 맵</param>
    /// <param name="tileType">찾을 타일의 타입</param>
    /// <returns></returns>
    public static List<List<Vector2Int>> GetRegions(int[,] map, TileType tileType)
    {
        //맵의 가로, 세로 길이 저장
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        //방문 여부를 저장할 맵과 같은 크키의 bool 배열 생성
        bool[,] visited = new bool[width, height];
        //
        List<List<Vector2Int>> regions = new();

        //맵의 가로, 세로 길이만큼 반복
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //아직 방문하지 않았고 타일 타입이 같다면 
                if (!visited[x, y] && map[x, y] == (int)tileType)
                {
                    //
                    List<Vector2Int> region = BFS(map, x, y, tileType, visited);
                    regions.Add(region);
                }
            }
        }

        return regions;
    }

    /// <summary>
    /// 타일 타입이 같은 좌표들을 BFS 탐색으로 찾아 저장한 구역을 반환
    /// </summary>
    /// <param name="map">맵</param>
    /// <param name="startX">시작점 x좌표</param>
    /// <param name="startY">시작점 y좌표</param>
    /// <param name="tileType">찾고 있는 타입</param>
    /// <param name="visited">방문 여부 배열</param>
    /// <returns>타일 타입이 같은 구역</returns>
    private static List<Vector2Int> BFS(int[,] map, int startX, int startY, TileType tileType, bool[,] visited)
    {
        //찾은 구역을 저장할 리스트
        List<Vector2Int> region = new();

        //BFS 탐색을 위한 큐 생성
        Queue<Vector2Int> queue = new();

        //시작좌표를 큐에 추가하고 방문처리
        queue.Enqueue(new Vector2Int(startX, startY));
        visited[startX, startY] = true;

        //큐가 비어있을 때까지 반복
        while (queue.Count > 0)
        {
            //큐에서 좌표를 하나 꺼내서 구역에 추가
            Vector2Int tile = queue.Dequeue();
            region.Add(tile);

            //좌표의 상하좌우 이웃 타일들을 탐색
            foreach (var dir in Directions)
            {
                //이웃 타일의 좌표 계산 후 저장
                int nx = tile.x + dir.x;
                int ny = tile.y + dir.y;

                //이웃 타일이 맵의 범위 내에 있는지 확인
                if (nx >= 0 && ny >= 0 && nx < map.GetLength(0) && ny < map.GetLength(1))
                {
                    //아직 방문하지 않았고 좌표와 타일 타입이 같다면
                    if (!visited[nx, ny] && map[nx, ny] == (int)tileType)
                    {
                        //밤문 처리하고 큐에 추가
                        visited[nx, ny] = true;
                        queue.Enqueue(new Vector2Int(nx, ny));
                    }
                }
            }
        }

        return region;
    }
}
