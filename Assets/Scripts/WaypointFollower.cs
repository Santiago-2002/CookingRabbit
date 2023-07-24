using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        // Selecciona el Waypoint hacia donse se mueve el objeto (secuencialmente)
        if(Vector2.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f){
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length){
                currentWaypointIndex = 0;
            }
        }

        // Una vez seleccionado se mueve el objeto hacia dicho waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);
    }
}
