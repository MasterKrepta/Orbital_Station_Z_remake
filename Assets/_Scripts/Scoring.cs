using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class  Scoring :MonoBehaviour {

    [SerializeField] GameObject finalTxt;
    public int EnemiesKilled { get; set; }

    private void OnEnable() {
        EventManager.OnEnemyKilled += UpdateScore;
        EventManager.OnGameOver += DisplayEndGame;
    }

    private void DisplayEndGame() {
        Debug.Log("End game");
        SceneManager.LoadScene(2);
        //TODO seperate out final scoring 
        finalTxt = GameObject.Find("txtFinalScore");
        finalTxt.GetComponent<TextMesh>().text = "Final Score: " + EnemiesKilled;
    }

    private void OnDisable() {
        EventManager.OnEnemyKilled -= UpdateScore;
        EventManager.OnGameOver -= DisplayEndGame;
    }

    private void UpdateScore() {
        EnemiesKilled++;
    }
}
