using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    private Image _hpBar;

    private void Awake()
    {
        TryGetComponent<Image>(out _hpBar);
    }

    private void OnEnable()
    {
        EventBus.AddListener<int>(EventType.PlayerHPChanged, UpdateHPUI);
    }

    private void OnDisable()
    {
        EventBus.RemoveListener<int>(EventType.PlayerHPChanged, UpdateHPUI);
    }

    private void UpdateHPUI(int hp)
    {
        _hpBar.fillAmount = hp / (float)PlayerSystems.Player.GetMaxHP();
    }
}
