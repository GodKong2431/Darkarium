using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsTimePaused { get; private set; } = false;
    public Canvas CurrentCanvas { get; private set; } = null;
    [SerializeField] public GameObject Player;

    public GameManager()
    {
        Instance = this;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetTimeScale(float newTimeScale)
    {
        if(newTimeScale == 0f)
        {
            IsTimePaused = true;
            InputSystem.actions.FindActionMap("Player").Disable();
        }
        else
        {
            IsTimePaused = false;
            InputSystem.actions.FindActionMap("Player").Enable();
        }

        Time.timeScale = newTimeScale;
    }

    public void SetCurrentCanvas(Canvas canvas = null)
    {
        CurrentCanvas = canvas;
    }
}
