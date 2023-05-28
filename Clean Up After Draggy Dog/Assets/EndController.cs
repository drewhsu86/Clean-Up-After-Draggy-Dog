using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    private float currentScore;
    private float highScore; 
    [SerializeField] TMP_Text scoreDisplay;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        currentScore = PlayerPrefs.GetFloat("CurrentScore");
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetFloat("HighScore");
            if (currentScore < highScore) {
                highScore = currentScore;
                PlayerPrefs.SetFloat("HighScore", highScore);
            } 
        } else {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        scoreDisplay.text = $"Your Score: {secToString(currentScore)} \n High Score: {secToString(highScore)}";
    }

    void Update() {
        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel")) {
            BackToMenu();
        }
    }

    private string secToString(float sec) {
        TimeSpan t = TimeSpan.FromSeconds(sec);
        return $"{t.Minutes:D2}:{t.Seconds:D2}";
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
