using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    private CinemachineCamera _playerCamera;

    private InputAction _zoom;
    private float _zoomInput;
    private float _zoomSpeed = 0.3f;


    private void Awake()
    {
        _playerCamera = GetComponent<CinemachineCamera>();
        _zoom = InputSystem.actions["ScrollWheel"];
    }

    private void Start()
    {
        _playerCamera.Target.TrackingTarget = GameManager.Instance.Player.transform;
    }

    private void OnEnable()
    {
        _zoom.performed += ctx => _zoomInput = ctx.ReadValue<Vector2>().y;
        _zoom.canceled += ctx => _zoomInput = 0f;
    }

    private void Update()
    {
        if (_zoomInput != 0f)
        {
            float newFov = _playerCamera.Lens.OrthographicSize - _zoomInput * _zoomSpeed;
            _playerCamera.Lens.OrthographicSize = Mathf.Clamp(newFov, 5f, 15f);
        }
    }
    private void OnDisable()
    {
        _zoom.performed -= ctx => _zoomInput = ctx.ReadValue<Vector2>().y;
        _zoom.canceled -= ctx => _zoomInput = 0f;
    }
}
