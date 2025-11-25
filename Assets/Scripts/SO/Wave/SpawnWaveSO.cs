using UnityEngine;

[CreateAssetMenu(menuName = "SO/SpawnWave")]
public class SpawnWaveSO : ScriptableObject
{
    [System.Serializable]
    public struct SpawnInfo
    {
        public MonsterSO monster;   // 어떤 몬스터?
        public int count;           // 몇 마리?
        public float delay;         // 몇 초 간격으로 소환?
    }

    public SpawnInfo[] waves;       // 여러 웨이브 저장
}
