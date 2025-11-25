using UnityEngine;
using UnityEngine.UI;

public class MinimapGenerator : MonoBehaviour
{
    //생성된 맵 가지고 오는 용도의 _dungeon
    [SerializeField] private DungeonGenerator _dungeon;

    //바꿀 이미지
    [SerializeField] private RawImage _minimapImage;


    [Header("Color")]
    [SerializeField] private Color _floorColor;
    [SerializeField] private Color _wallColor;

    
    private Texture2D _minimapTex;
    private int[,] _map;


    private void Start()
    {
        GenerateMinimap();
    }

    /// <summary>
    /// 미니맵 텍스쳐 설정하고 이미지에 적용하는 메서드
    /// </summary>
    public void GenerateMinimap()
    {
        //DungeonGenerator가 제작한 맵을 가져옴
        _map = _dungeon.map.Map;

        //맵의 가로, 세로 길이를 가져옴
        int width = _map.GetLength(0);
        int height = _map.GetLength(1);

        //미니맵 텍스쳐를 맵의 크기와 똑같은 픽셀단위로 만듬
        _minimapTex = new Texture2D(width, height);

        //텍스쳐의 모드를 point로 바꿈
        _minimapTex.filterMode = FilterMode.Point;

        //맵의 정보를 바탕으로 픽셀 칸에 벽과 바닥을 색칠
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = _map[x, y] == 1 ? _wallColor : _floorColor;
                _minimapTex.SetPixel(x, y, color);
            }
        }

        //변경한 텍스쳐 정보를 적용
        _minimapTex.Apply();

        //이미지에 텍스쳐 적용
        _minimapImage.texture = _minimapTex;
    }
}