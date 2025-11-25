using UnityEngine;

public static class CellularAutomata
{
    /// <summary>
    /// 초기로 맵의 크기와 fillPercent만큼 벽으로 채운 맵배열을 반환
    /// </summary>
    /// <param name="width">맵의 가로 길이</param>
    /// <param name="height">맵의 세로 길이</param>
    /// <param name="fillPercent">벽으로 채울 비율</param>
    /// <returns>초기 생성된 맵(2차원 배열)</returns>
    public static int[,] GenerateRandomMap(int width, int height, int fillPercent)
    {
        //배열 생성
        int[,] map = new int[width, height];

        //배열의 가로 세로 길이만큼 반복
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //배열의 테두리
                bool isBorder = x == 0 || y == 0 || x == width - 1 || y == height - 1;

                //if(isBorder)
                //{
                //    map[x, y] = 1;
                //    continue;
                //}
                //if ((Random.Range(0, 100) < fillPercent))
                //{
                //    map[x, y] = 1;
                //}
                //else
                //{
                //    map[x, y] = 0;
                //}
                
                //배열의 테두리는 벽으로 나머지는 fillPercent의 비율만큼 벽으로 생성
                map[x, y] = isBorder ? (int)TileType.Wall : (Random.Range(0, 100) < fillPercent ? (int)TileType.Wall : (int)TileType.Floor);
            }
        }

        return map;
    }

    /// <summary>
    /// 맵(2차원 배열) 을 스무딩해서 반환
    /// </summary>
    /// <param name="map">맵(2차원 배열)</param>
    /// <returns>스무딩한 맵(2차원 배열)</returns>
    public static int[,] Smooth(int[,] map)
    {
        //맵의 가로, 세로 길이 저장
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        //스무딩한 맵을 저장할 배열을 생성
        int[,] newMap = new int[width, height];

        //맵의 가로, 세로 길이만큼 반복
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                //중심칸 기준 주변 8칸의 벽 개수 구해옴
                int wallCount = CountWallsAround(map, x, y);

                //벽 개수가 4개 초과면 벽으로, 미만이면 바닥으로, 둘 다 같으면 기존 값으로 유지하기
                if (wallCount > 4) newMap[x, y] = (int)TileType.Wall;
                else if (wallCount < 4) newMap[x, y] = (int)TileType.Floor;
                else newMap[x, y] = map[x, y];
            }
        }

        return newMap;
    }

    /// <summary>
    /// 중심칸 기준으로 주변 8칸의 벽 개수를 반환
    /// </summary>
    /// <param name="map">맵(2차원 배열)</param>
    /// <param name="x">맵의 가로 칸</param>
    /// <param name="y">맵의 세로 칸</param>
    /// <returns>주변 8칸의 벽 개수</returns>
    private static int CountWallsAround(int[,] map, int x, int y)
    {
        //벽의 개수를 저장하는 변수
        int count = 0;

        //맵의 가로, 세로 길이 저장
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        //가로 세로 -1 ~ +1 칸을 반복
        for (int nx = x - 1; nx <= x + 1; nx++)
        {
            for (int ny = y - 1; ny <= y + 1; ny++)
            {
                //반복하는 칸이 맵 범위 내에 있는지 확인
                if (nx >= 0 && ny >= 0 && nx < width && ny < height)
                {
                    //중심칸이 아닌경우 벽은 1로 저장하기 때문에 더해서 count 증가
                    if (nx != x || ny != y)
                        count += map[nx, ny];
                }
                //맵 범위 밖인 경우 벽으로 간주해서 count 증가
                else count++; 
            }
        }

        return count;
    }
}
