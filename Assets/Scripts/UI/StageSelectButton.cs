using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    private Button _button;

    [SerializeField] private Button[] _stageButtons;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(
            () =>{
                foreach (var button in transform.parent.GetComponentsInChildren<Button>())
                {
                    if (button.TryGetComponent<MenuCloseButton>(out var temp))
                        continue;
                    button.gameObject.SetActive(false);
                }
                foreach (var button in _stageButtons)
                {
                    button.gameObject.SetActive(true);
                }
            }
            );
    }
}
