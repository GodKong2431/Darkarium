using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnWaveSO waveData;

    private DungeonData _dungeon;
    public float startDelay = 2f;

    public void Init(DungeonGenerator dungeonData)
    {
        _dungeon = dungeonData.map;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        foreach (var wave in waveData.waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.monster);
                yield return new WaitForSeconds(wave.delay);
            }
        }
    }

    private void SpawnEnemy(MonsterSO monster)
    {
        if (_dungeon.Rooms.Count == 0) return;

        // 1) 랜덤한 방 선택
        int roomIndex = Random.Range(0, _dungeon.Rooms.Count);
        List<Vector2Int> roomTiles = _dungeon.Rooms[roomIndex];
        if (roomTiles.Count == 0) return;

        // 2) 랜덤한 바닥 타일 선택
        Vector2Int tile = roomTiles[Random.Range(0, roomTiles.Count)];

        Vector3 spawnPos = new Vector3(tile.x + 0.5f, tile.y + 0.5f, 0);

        // 3) 몬스터 생성
        Instantiate(monster.prefab, spawnPos, Quaternion.identity);
    }
}
