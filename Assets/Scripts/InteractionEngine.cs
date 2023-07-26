using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEngine : MonoBehaviour
{
    [SerializeField] private GameObject statsRenderer;
    private StatsController statsRendererController;

    [SerializeField] private GameObject gameOverRenderer;
    private GameOverController gameoverRendererController;

    private Animator animator;
    private CharacterStatsManager manager;

    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GetComponent<CharacterStatsManager>();
        statsRendererController = statsRenderer.transform.GetComponent<StatsController>();
        gameoverRendererController = gameOverRenderer.transform.GetComponent<GameOverController>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
        switch(collider.tag){
            case "Trampa":
                Debug.Log("TRAMPA");
                manageDeath();
                break;
            case "FallDetector":
                Debug.Log("Caída");
                manageDeath();
                break;
            case "Collectable1":
                Debug.Log("Collectable1");
                manager.increseItem1(1);
                Debug.Log(manager.getItems());
                renderItems();
                break;
            case "Collectable2":
                Debug.Log("Collectable2");
                manager.increseItem2(1);
                renderItems();
                break;
            case "Collectable3":
                Debug.Log("Collectable3");
                manager.increseItem3(1);
                renderItems();
                break;
            /*case "Power1":
                Debug.Log("Power1");
                manager.setPower1(true);
                renderPowers();
                break;
            case "Power2":
                Debug.Log("Power2");
                manager.setPower2(true);
                renderPowers();
                break;
            case "Power3":
                Debug.Log("Power3");
                manager.setPower3(true);
                renderPowers();
                break;*/
        }
    }

    private void manageDeath(){
        //animator.SetTrigger("desappear");
        manager.decreseLives();
        Debug.Log("Vidas: " + manager.getLives());
        renderLives();
        if(manager.getLives() <= 0){
            Debug.Log("GAME OVER");
            gameoverRendererController.setActive(true);
        }
        else{
            StartCoroutine(respawnCharacter());
        }
    }

    private IEnumerator respawnCharacter(){
        Debug.Log("Respawn Character at " + manager.getRespawnPoint());
        yield return new WaitForSeconds(1);
        //animator.SetTrigger("respawn");
        transform.position = manager.getRespawnPoint();
    }

    private void renderScore(){
        statsRendererController.updateScore(manager.getScore());
    }
    private void renderLives(){
        int lives = manager.getLives();
        statsRendererController.updateLives((lives>=1?true:false,lives>=2?true:false,lives>=3?true:false));
    }
    private void renderItems(){
        statsRendererController.updateItems(manager.getItems());
        renderScore();
    }
    /*private void renderPowers(){
        statsRendererController.updatePowers(manager.getPowers());
    }*/
}
