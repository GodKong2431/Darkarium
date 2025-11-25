using UnityEngine;
using UnityEngine.UI;

public class MinimapPlayerIcon : MonoBehaviour
{

    [SerializeField] private RectTransform playerIcon;
    [SerializeField] private RawImage minimapImage;
    [SerializeField] private Transform player;
    [SerializeField] private DungeonGenerator dungeon;

    private int width;
    private int height;
    private bool initialized = false;

    void FixedUpdate()
    {
        //일단 위의 맵 생성 확인만 실행
        if (!initialized)
        {
            //맵이 생성되어 있다면 크기를 저장하고 if문 실행하지 않음
            if (dungeon.map.Map != null)
            {
                width = dungeon.map.Map.GetLength(0);
                height = dungeon.map.Map.GetLength(1);
                initialized = true;
            }
            else
            {
                return; // 아직 맵 생성 안 됨
            }
        }

        //플레이어 포지션을 저장
        Vector3 pos = player.position;

        //월드좌표를 내림해서 저장
        int mapX = Mathf.FloorToInt(pos.x);
        int mapY = Mathf.FloorToInt(pos.y);

        //내림한 좌표를 UI의 최대 크기로 나눠서 저장
        float uiX = (float)mapX / width * minimapImage.rectTransform.sizeDelta.x;
        float uiY = (float)mapY / height * minimapImage.rectTransform.sizeDelta.y;

        //UI의 위치를 저장한 위치로 변경
        playerIcon.anchoredPosition = new Vector2(uiX, uiY);

    }
}
