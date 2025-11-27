using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    private Button _button;

    [SerializeField] private Transform[] _SelectUIs;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(
            () =>{
                GameManager.Instance.EnableUI(_button.transform.parent, _SelectUIs);
            });
    }
}
