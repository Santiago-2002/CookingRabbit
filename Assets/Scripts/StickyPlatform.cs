using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.name == "Player2"){
            collider.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.name == "Player2"){
            collider.gameObject.transform.SetParent(null);
        }
    }
}
