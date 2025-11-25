using UnityEngine;
using UnityEngine.UI;

public class MinimapGenerator : MonoBehaviour
{
    public DungeonGenerator dungeon;
    public RawImage minimapImage;
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
        map = dungeon.map.Map;
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        minimapTex = new Texture2D(width, height);
        minimapTex.filterMode = FilterMode.Point;

        // ÇÈ¼¿ »ö Ä¥ÇÏ±â
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = map[x, y] == 1 ? wallColor : floorColor;
                minimapTex.SetPixel(x, y, color);
            }
        }

        minimapTex.Apply();

        // UI¿¡ Àû¿ë
        minimapImage.texture = minimapTex;
    }
}