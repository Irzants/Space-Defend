using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WayConfig", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabas;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeSpawnEnemy = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawmTime = 0.2f;

    //make list enemy
    public int GetEnemyCount()
    {
        return enemyPrefabas.Count;
    }


    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabas[index];
    }
    

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    //add list enemy
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


    //make random spawn time between waves
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeSpawnEnemy - spawnTimeVariance,
                                        timeSpawnEnemy + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawmTime, float.MaxValue);
    }

}
