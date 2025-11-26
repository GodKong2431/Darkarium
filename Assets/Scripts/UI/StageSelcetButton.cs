using UnityEngine;
using UnityEngine.UI;

public class StageSelcetButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(
            () => {
                SceneChanger.SceneLoad(SceneType.Map);
            });
    }
}
