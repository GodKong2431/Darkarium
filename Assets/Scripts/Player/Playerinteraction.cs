using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerInteraction : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _interactUI;

    [Header("Input")]
    [SerializeField] private InputActionReference _interact;

    [SerializeField] private Vector3 _offset;
    private Camera _camera;

    private bool canInteract = false;
    private IInteractable _currentInteractUI;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _interact.action.started += OnInteract;
        _interact.action.Disable();
    }

    private void OnDisable()
    {
        _interact.action.started -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (canInteract && _currentInteractUI != null)
        {
            _currentInteractUI.OnInteract();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable target))
        {
            _currentInteractUI = target;
            _interactUI.SetActive(true);
            _interact.action.Enable();
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable target) && target == _currentInteractUI)
        {
            _currentInteractUI = null;
            _interactUI.SetActive(false);
            _interact.action.Disable();
            canInteract = false;
        }
    }

    private void LateUpdate()
    {
        Vector3 screenPos = _camera.WorldToScreenPoint(transform.position + _offset);

        _interactUI.transform.position = screenPos;
    }
}
