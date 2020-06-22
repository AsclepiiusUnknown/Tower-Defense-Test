using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    #region Variables
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;
    #endregion

    #region Setup
    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }
    #endregion

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        //Move towards the next waypoint
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //We are close enough so get the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= enemy.minDistanceToPoint)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed; //resetting the speed (kind sketchy?)
    }

    #region Get Next Waypoint
    //Get the next waypoint int he given array
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    #endregion

    #region Reached End of Pathway
    //We have reached the end of the pathway so reduce the lives by one and the number of enemies alive and then destroy itself
    void EndPath()
    {
        PlayerStats.ReduceLives(1);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    #endregion
}
