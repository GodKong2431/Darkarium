using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    [SerializeField] private DungeonGenerator _dungeon;

    void Start()
    {
        _spawner.SpawnStart(_dungeon);
    }
}
