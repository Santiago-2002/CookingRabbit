using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointRotation : MonoBehaviour
{
    [SerializeField] private int anguloA = -45;
    [SerializeField] private int anguloB = 45;
    [SerializeField] private float speed = 60f;

    private bool _waypoint = true;    
    
    void Update()
    {
        // Selecciona el angulo hacia donse se mueve el objeto (secuencialmente)
        if(Quaternion.Angle(transform.rotation, _waypoint?Quaternion.Euler(0,0,anguloA):Quaternion.Euler(0,0,anguloB)) < 0.1f){
            _waypoint = !_waypoint;
        }

        // Una vez seleccionado se mueve el objeto hacia dicho waypoint
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _waypoint?Quaternion.Euler(0,0,anguloA):Quaternion.Euler(0,0,anguloB), speed*Time.deltaTime);
    }
}
