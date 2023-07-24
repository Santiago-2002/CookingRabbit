using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    private GameObject gameOverPanel;

    public void Start() {
        gameOverPanel = transform.GetChild(0).gameObject;
    }

    public void setActive(bool status){
        gameOverPanel.SetActive(status);
    }
}
