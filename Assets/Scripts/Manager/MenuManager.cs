using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas _menuCanvas;

    InputAction _openMenu;
    private bool _isMenuOpen = false;
    

    private void Awake()
    {
        _openMenu = InputSystem.actions["OpenMenu"];
    }

    private void OnEnable()
    {
        _openMenu.started += ctx =>
        {
            if (GameManager.Instance.CurrentCanvas == _menuCanvas || GameManager.Instance.CurrentCanvas == null)
            {
                _isMenuOpen = !_isMenuOpen;
                OpenMenu();
            }
        };
    }

    private void OnDisable()
    {
        _openMenu.Disable();
    }

    private void OpenMenu()
    {
        if (_isMenuOpen)
        {
            GameManager.Instance.SetTimeScale(0f);
            GameManager.Instance.SetCurrentCanvas(_menuCanvas);
            _menuCanvas.gameObject.SetActive(_isMenuOpen);
        }
        else
        {
            GameManager.Instance.SetTimeScale(1f);
            GameManager.Instance.SetCurrentCanvas(null);
            _menuCanvas.gameObject.SetActive(_isMenuOpen);
        }  
    }
}
