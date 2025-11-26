using UnityEngine;
using UnityEngine.InputSystem;


public class OpenMenuInteractable : MonoBehaviour, IInteractable
{
    public GameObject menuUI;

    [SerializeField] private Transform[] _defaultButtons;
    public void OnInteract()
    {
        menuUI.SetActive(true);
        foreach (Transform child in menuUI.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform button in _defaultButtons)
        {
            button.gameObject.SetActive(true);
        }
        InputSystem.actions.FindActionMap("Player").Disable();
    }
}
