using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _enemyTypeDropDown;
    [SerializeField] private Slider _enemyCountSlider;
    [SerializeField] private Slider _mapSizeSlider;


    [SerializeField] private List<MonsterSO> _monsterList;
    [SerializeField] private StageInfoSO _stageInfoSO;

    [SerializeField] private TextMeshProUGUI _enemyCountText;
    [SerializeField] private TextMeshProUGUI _mapSizeText;

    private void Start()
    {
        SetDropdown();
    }

    private void OnEnable()
    {
        _enemyTypeDropDown.onValueChanged.AddListener(OnDropdownChanged);
        _enemyCountSlider.onValueChanged.AddListener(OnEnemyCountSliderChanged);
        _mapSizeSlider.onValueChanged.AddListener(OnMapSizeSliderChanged);
    }

    private void OnDisable()
    {
        _enemyTypeDropDown.onValueChanged.RemoveListener(OnDropdownChanged);
        _enemyCountSlider.onValueChanged.RemoveListener(OnEnemyCountSliderChanged);
        _mapSizeSlider.onValueChanged.RemoveListener(OnMapSizeSliderChanged);
    }

    private void SetDropdown()
    {
        _enemyTypeDropDown.ClearOptions();

        List<string> names = new List<string>();
        foreach (var monster in _monsterList)
        {
            names.Add(monster.name);
        }
        _enemyTypeDropDown.AddOptions(names);

        _stageInfoSO.spawn.monster = _monsterList[0];
    }

    private void OnDropdownChanged(int index)
    {
        _stageInfoSO.spawn.monster = _monsterList[index];
        Debug.Log($"WaveSOø° '{_stageInfoSO.spawn.monster.name}' ¿˙¿Âµ ");
    }

    private void OnEnemyCountSliderChanged(float value)
    {
        _stageInfoSO.spawn.count = (int)(value * 500);
        _enemyCountText.text = $"EnemyCount({_stageInfoSO.spawn.count})";
    }
    private void OnMapSizeSliderChanged(float value)
    {
        _stageInfoSO.map.size = (int)(value * 100);
        _mapSizeText.text = $"MapSize({_stageInfoSO.map.size})";
    }
}
