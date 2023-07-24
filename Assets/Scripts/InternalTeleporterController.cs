using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternalTeleporterController : MonoBehaviour
{
    [SerializeField] private AudioSource teleporter_SFX;
    [SerializeField] private GameObject destinationWaypoint;

    private GameObject personaje;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            Debug.Log("Internal Teleporter");
            teleporter_SFX.Play();
            animator.SetTrigger("collected");
            personaje = collider.gameObject;
            teleportPlayer();
        }
    }

    private void teleportPlayer(){
        personaje.GetComponent<Animator>().SetTrigger("desappear");
        StartCoroutine(teleportWithAudio(destinationWaypoint.transform.position, teleporter_SFX));
    }

    private IEnumerator teleportWithAudio(Vector3 waypoint, AudioSource audio){
      Debug.Log("[Desappear]Yield Init");
      yield return new WaitUntil(() => audio.isPlaying == false); // Se ejecuta esta línea hasta que la condición sea verdadera
      Debug.Log("[Desappear]Yield Over");
      personaje.transform.position = waypoint;
      yield return new WaitForSeconds(0.7f);
      personaje.GetComponent<Animator>().SetTrigger("respawn");
      Destroy(this);
   }
}
