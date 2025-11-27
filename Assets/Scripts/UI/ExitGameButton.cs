using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Enable()
    {
        _button.onClick.AddListener(
            () =>
            {
                Application.Quit();
            });
    }
}
