using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private StageInfoSO _stageInfo;

    private DungeonData _dungeon;
    [SerializeField] private float _startDelay = 2f;


    public void SpawnStart(DungeonGenerator dungeonData)
    {
        _dungeon = dungeonData.map;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(_startDelay);

        GameManager.Instance.IsSpawning = true;

        if(_stageInfo.spawn.count == 0)
        {
            GameManager.Instance.IsSpawning = false;
            GameManager.Instance.EnemyDie();
        }

        for (int i = 0; i < _stageInfo.spawn.count; i++)
        {
            SpawnEnemy(_stageInfo.spawn.monster);
            GameManager.Instance.EnemySpawn();
            yield return new WaitForSeconds(_stageInfo.spawn.delay);
        }

        GameManager.Instance.IsSpawning = false;
    }

    private void SpawnEnemy(MonsterSO monster)
    {
        if (_dungeon.Rooms.Count == 0) return;

        //랜덤한 방 선택
        int roomIndex = Random.Range(0, _dungeon.Rooms.Count);
        List<Vector2Int> roomTiles = _dungeon.Rooms[roomIndex];
        if (roomTiles.Count == 0) return;

        //랜덤한 바닥 타일 선택
        Vector2Int tile = roomTiles[Random.Range(0, roomTiles.Count)];

        Vector3 spawnPos = new Vector3(tile.x + 0.5f, tile.y + 0.5f, 0);

        //몬스터 생성
        Instantiate(monster.prefab, spawnPos, Quaternion.identity);
    }
}
