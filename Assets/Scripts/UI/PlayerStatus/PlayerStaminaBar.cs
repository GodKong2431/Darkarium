using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    private Image _staminaBar;

    private void Awake()
    {
        TryGetComponent<Image>(out _staminaBar);
    }

    private void OnEnable()
    {
        EventBus.AddListener<int>(EventType.PlayerStaminaChanged, UpdateStaminaUI);
    }

    private void OnDisable()
    {
        EventBus.RemoveListener<int>(EventType.PlayerStaminaChanged, UpdateStaminaUI);
    }

    private void UpdateStaminaUI(int stamina)
    {
        _staminaBar.fillAmount = stamina / (float)PlayerSystems.Player.GetMaxStamina();
    }
}
