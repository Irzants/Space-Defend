using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayFinder : MonoBehaviour
{

    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig; // call script
    List<Transform> waypoints;
    int wayPointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }


    //enemy following path point by index
    void FollowPath()
    {
        if(wayPointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
