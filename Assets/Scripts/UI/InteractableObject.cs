using UnityEngine;
using UnityEngine.InputSystem;


public class OpenMenuInteractable : MonoBehaviour, IInteractable
{
    public GameObject menuUI;

    [SerializeField] private Transform[] _defaultButtons;
    public void OnInteract()
    {
        menuUI.SetActive(true);
        GameManager.Instance.EnableUI(menuUI.transform, _defaultButtons);
        InputSystem.actions.FindActionMap("Player").Disable();
    }
}
