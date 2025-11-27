using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    private TextMeshProUGUI _goldText;

    private void Awake()
    {
        TryGetComponent<TextMeshProUGUI>(out _goldText);
    }


    private void OnEnable()
    {
        EventBus.AddListener<int>(EventType.PlayerGoldChanged, UpdateGoldUI);
    }

    private void OnDisable()
    {
        EventBus.RemoveListener<int>(EventType.PlayerGoldChanged, UpdateGoldUI);
    }

    private void UpdateGoldUI(int gold)
    {
        _goldText.text = $"{gold}G";
    }
}
