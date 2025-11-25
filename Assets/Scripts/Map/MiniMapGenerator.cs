using UnityEngine;
using UnityEngine.UI;

public class MinimapGenerator : MonoBehaviour
{
    public DungeonGenerator dungeon;    // 너가 만든 CA+타일맵 생성 코드
    public RawImage minimapImage;       // UI에 표시할 RawImage
    public Color floorColor = Color.white;
    public Color wallColor = Color.black;

    private Texture2D minimapTex;
    private int[,] map;

    private void Start()
    {
        GenerateMinimap();
    }

    public void GenerateMinimap()
    {
        map = dungeon.map.Map;  // 생성된 CA 맵 가져오기
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        minimapTex = new Texture2D(width, height);
        minimapTex.filterMode = FilterMode.Point;

        // 픽셀 색 칠하기
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = map[x, y] == 1 ? wallColor : floorColor;
                minimapTex.SetPixel(x, y, color);
            }
        }

        minimapTex.Apply();

        // UI에 적용
        minimapImage.texture = minimapTex;
    }
}