using UnityEngine;
using UnityEngine.UI;

public class PlayerMPBar : MonoBehaviour
{
    private Image _mpBar;

    private void Awake()
    {
        TryGetComponent<Image>(out _mpBar);
    }

    private void OnEnable()
    {
        EventBus.AddListener<int>(EventType.PlayerMPChanged, UpdateMPUI);
    }

    private void OnDisable()
    {
        EventBus.RemoveListener<int>(EventType.PlayerMPChanged, UpdateMPUI);
    }

    private void UpdateMPUI(int mp)
    {
        _mpBar.fillAmount = mp / (float)PlayerSystems.Player.GetMaxMP();
    }
}
