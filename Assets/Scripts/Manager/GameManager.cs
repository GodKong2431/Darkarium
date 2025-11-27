using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : SingleTon<GameManager>
{

    public bool IsTimePaused { get; private set; } = false;
    public Canvas CurrentCanvas { get; private set; } = null;
    [SerializeField] public GameObject Player;

    public GameData GameData { get; private set; }
    private int _aliveMonsterCount = 0;

    public bool IsSpawning {  get; set; }

    protected override void Awake()
    {
        base.Awake();
        GameData = GameDataManager.Load();
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

    public void EnableUI(Transform parent, Transform[] onUI)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform ui in onUI)
        {
            ui.gameObject.SetActive(true);
        }
    }

    public void InvokeGameOver()
    {
        Invoke("GameOver", 5);
    }

    private void GameOver()
    {
        InputSystem.actions.FindActionMap("Player").Enable();
        PlayerSystems.Player.ChangeCurrentHP(PlayerSystems.Player.GetMaxHP());
        PlayerSystems.Player.PlayerView.Anim.SetTrigger("Restart");
        Player.transform.position = new Vector3(2.5f, 6.5f, 0);
        SceneChanger.SceneLoad(SceneType.Village);

    }

    public void Victory()
    {
        PlayerSystems.Player.ChangeCurrentHP(PlayerSystems.Player.GetMaxHP());
        Player.transform.position = new Vector3(2.5f, 6.5f, 0);
        SceneChanger.SceneLoad(SceneType.Village);
    }

    public void EnemySpawn()
    {
        _aliveMonsterCount += 1;
    }

    public void EnemyDie()
    {
        _aliveMonsterCount -= 1;
        if (_aliveMonsterCount <= 0 && !IsSpawning)
        {
            _aliveMonsterCount = 0;
            Invoke("Victory", 5);
        }
    }
    private void OnDisable()
    {
        GameDataManager.Save(GameData);
    }
    private void OnApplicationQuit()
    {
        GameDataManager.Save(GameData);
    }
}
