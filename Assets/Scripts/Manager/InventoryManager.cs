using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Canvas _inventoryCanvas;

    InputAction _openInventory;
    private bool _isInventoryOpen = false;
    

    private void Awake()
    {
        _openInventory = InputSystem.actions["OpenInventory"];
    }

    private void OnEnable()
    {
        _openInventory.started += ctx =>
        {
            if(GameManager.Instance.CurrentCanvas == _inventoryCanvas || GameManager.Instance.CurrentCanvas == null)
            {
                _isInventoryOpen = !_isInventoryOpen;
                OpenInvenTory();
            }
        };
    }

    private void OnDisable()
    {
        _openInventory.Disable();
    }

    private void OpenInvenTory()
    {
        if (_isInventoryOpen)
        {
            GameManager.Instance.SetTimeScale(0f);
            GameManager.Instance.SetCurrentCanvas(_inventoryCanvas);
            _inventoryCanvas.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.SetTimeScale(1f);
            GameManager.Instance.SetCurrentCanvas(null);
            _inventoryCanvas.gameObject.SetActive(false);
        }
    }
}
