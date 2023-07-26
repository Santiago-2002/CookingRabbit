using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager statsManager;

    private Vector3 respawnPoint;
    private int lives = 3;
    private int score = 0;
    private int[] items = new int[]{0,0,0};
    //private bool[] powers = new bool[]{false,false,false};

    private int scoreForItem1 = 1;
    private int scoreForItem2 = 2;
    private int scoreForItem3 = 3;
    //private int scoreForPower = 10;

    private float respawnHigh = 6f;


    private void Start()
    {
        // Se crea un SINGLETON del objeto que mantiene las estadísticas del personaje
        if(statsManager == null){
            statsManager = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(this);
        }
        respawnPoint = new Vector3(0,respawnHigh,0);
    }

    public void setScore(int _score){
        score = _score;
    }
    public int getScore(){
        return score;
    }
    public int raiseScore(int _plusScore){
        score += _plusScore;
        return score;
    }

    public int getLives(){
        return lives;
    }
    public int decreseLives(){
        lives--;
        return lives;
    }
    public int increseLives(){
        lives++;
        return lives;
    }

    public (int, int, int) getItems(){
        return (items[0], items[1], items[2]);
    }
    public void setItems((int item1, int item2, int item3)_items){
        items[0] = _items.item1;
        items[1] = _items.item2;
        items[2] = _items.item3;
    }
    public int increseItem1(int _item){
        items[0] += _item;
        raiseScore(scoreForItem1);
        return items[0];
    }
    public int increseItem2(int _item){
        items[1] += _item;
        raiseScore(scoreForItem2);
        return items[1];
    }
    public int increseItem3(int _item){
        items[2] += _item;
        raiseScore(scoreForItem3);
        return items[2];
    }

    /*public (bool, bool, bool) getPowers(){
        return (powers[0], powers[1], powers[2]);
    }
    public void setPowers((bool item1, bool item2, bool item3)_powers){
        powers[0] = _powers.item1;
        powers[1] = _powers.item2;
        powers[2] = _powers.item3;
    }
    public bool setPower1(bool _power){
        powers[0] = _power;
        raiseScore(scoreForPower);
        return powers[0];
    }
    public bool setPower2(bool _power){
        powers[1] = _power;
        raiseScore(scoreForPower);
        return powers[1];
    }
    public bool setPower3(bool _power){
        powers[2] = _power;
        raiseScore(scoreForPower);
        return powers[2];
    }*/

    public void setRespawnPoint(Vector3 _respawnPoint){
        respawnPoint = new Vector3(_respawnPoint[0], respawnHigh, _respawnPoint[2]);
    }
    public Vector3 getRespawnPoint(){
        return respawnPoint;
    }

}