using UnityEngine;

[CreateAssetMenu(menuName = "SO/StageInfoSO")]
public class StageInfoSO : ScriptableObject
{
    [System.Serializable]
    public struct SpawnInfo
    {
        public MonsterSO monster;   
        public int count;           
        public float delay;         
    }

    [System.Serializable]
    public struct mapInfo
    {
        public int size;
    }

    public SpawnInfo spawn;       
    public mapInfo map;       
}
