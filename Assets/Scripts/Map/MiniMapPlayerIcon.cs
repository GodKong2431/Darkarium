using UnityEngine;
using UnityEngine.UI;

public class MinimapPlayerIcon : MonoBehaviour
{
    public RectTransform playerIcon;
    public RawImage minimapImage;
    public Transform player;
    public DungeonGenerator dungeon;

    private int width;
    private int height;
    private bool initialized = false;


    void Update()
    {
        if (!initialized)
        {
            if (dungeon.map.Map != null)
            {
                width = dungeon.map.Map.GetLength(0);
                height = dungeon.map.Map.GetLength(1);
                initialized = true;
            }
            else
            {
                return; // ¾ÆÁ÷ ¸Ê »ý¼º ¾È µÊ
            }
        }

        Vector3 pos = player.position;

        // ¿ùµå ÁÂÇ¥ ¡æ ¸Ê ÁÂÇ¥
        int mapX = Mathf.FloorToInt(pos.x);
        int mapY = Mathf.FloorToInt(pos.y);

        // ¸Ê ÁÂÇ¥ ¡æ ¹Ì´Ï¸Ê UI ÁÂÇ¥
        float uiX = (float)mapX / width * minimapImage.rectTransform.sizeDelta.x;
        float uiY = (float)mapY / height * minimapImage.rectTransform.sizeDelta.y;

        playerIcon.anchoredPosition = new Vector2(uiX, uiY);
    }
}
