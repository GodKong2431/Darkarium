using UnityEngine;
using UnityEngine.UI;

public class MainStartButton : MonoBehaviour
{
    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnStart);
    }

    public void OnStart()
    {
        SceneChanger.SceneLoad(SceneType.Village);
    }
}
