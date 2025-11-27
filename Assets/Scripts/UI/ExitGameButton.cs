using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
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
                Application.Quit();
            });
    }
}
