using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _hpUpButton;
    [SerializeField] private TextMeshProUGUI _hpUpText;

    [SerializeField] private Button _atkUpButton;
    [SerializeField] private TextMeshProUGUI _atkUpText;

    [SerializeField] private Button _staminaUpButton;
    [SerializeField] private TextMeshProUGUI _staminaUpText;

    private void Start()
    {
        HpTextUpdate();
        AtkTextUpdate();
        StaminaUpdate();
    }

    private void OnEnable()
    {
        _hpUpButton.onClick.AddListener(HpUp);
        _atkUpButton.onClick.AddListener(AtkUp);
        _staminaUpButton.onClick.AddListener(StaminaUp);
    }

    private void HpUp()
    {
        if (PlayerSystems.Player.GetGold() >= 100)
        {
            PlayerSystems.Player.ChangeGold(-100);
            PlayerSystems.Player.ChangeMaxHP(+10);
            HpTextUpdate();
        }
        
    }
    private void AtkUp()
    {
        if (PlayerSystems.Player.GetGold() >= 100)
        {
            PlayerSystems.Player.ChangeGold(-100);
            PlayerSystems.Player.ChangeDamage(+10);
            AtkTextUpdate();
        }
    }
    private void StaminaUp()
    {
        if(PlayerSystems.Player.GetGold() >= 100)
        {
            PlayerSystems.Player.ChangeGold(-100);
            PlayerSystems.Player.ChangeMaxStamina(+10);
            StaminaUpdate();
        }
    }

    private void HpTextUpdate()
    {
        _hpUpText.text = $"HP UP (100G) / {PlayerSystems.Player.GetMaxHP()}";
    }
    private void AtkTextUpdate()
    {
        _atkUpText.text = $"ATK UP (100G) / {PlayerSystems.Player.GetDamage()}";
    }
    private void StaminaUpdate()
    {
        _staminaUpText.text = $"Stamina UP (100G) / {PlayerSystems.Player.GetMaxStamina()}";
    }

}
