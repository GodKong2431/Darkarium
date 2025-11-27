using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StageStartButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(
            () =>
            {
                InputSystem.actions.FindActionMap("Player").Enable();
                SceneChanger.SceneLoad(SceneType.Map);
            });
    }
}
