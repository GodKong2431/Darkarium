using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuCloseButton : MonoBehaviour
{
    private Button _button;



    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(
            () =>{
                transform.parent.gameObject.SetActive(false);
                InputSystem.actions.FindActionMap("Player").Enable();
            });
    }
}
