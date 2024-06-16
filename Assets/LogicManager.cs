using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public GameObject gameOverScreen;
    public OtterScript otter;
    [ContextMenu("IncreaseScore")]
    void Start(){
        gameOverScreen.SetActive(false);
    }
    public void addScore(int scoreToAdd){ 
        if (otter.isOtterAlive){
            playerScore += scoreToAdd ;
            scoreText.text = playerScore.ToString();
            Debug.Log("Scored");
        }
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
    }
}
