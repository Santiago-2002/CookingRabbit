using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   public GameObject Player2; 

   
    void Update()
    {
        transform.position = new Vector3(Player2.transform.position.x, Player2.transform.position.y, transform.position.z);
    }
}
