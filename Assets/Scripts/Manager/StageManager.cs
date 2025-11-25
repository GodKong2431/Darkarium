using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    [SerializeField] private DungeonGenerator _dungeon;

    void Start()
    {
        _spawner.Init(_dungeon);
    }
}
