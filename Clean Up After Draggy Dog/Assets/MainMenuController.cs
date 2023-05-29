using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] List<GameObject> uiItems;
    [SerializeField] List<GameObject> buttonHighlights;
    [SerializeField] int selectedButton = 0;
    [SerializeField] float deadzone = 0.5f;
    [SerializeField] float canMoveButtonDelay = 0.3f;
    bool canMoveButton = true;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ClosePanels();
    }

    void Update() {    
        if (Input.GetButtonDown("Cancel")) {
            ClosePanels();
        } else if (Input.GetButtonDown("Submit")) {
            ActivateButton();
        }  
        DetectButtonSelect();
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void ShowStory() {
        uiItems[0].SetActive(true);
    }

    public void ShowCredits() {
        uiItems[1].SetActive(true);
    }

    public void ClosePanels() {
        foreach(GameObject item in uiItems) {
            item.SetActive(false);
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void DetectButtonSelect() {
        if (canMoveButton && Input.GetAxis("Vertical") != 0) {
            if (Input.GetAxis("Vertical") > deadzone) {
                IterateIndex(false);
            } else if (Input.GetAxis("Vertical") < -deadzone) {
                IterateIndex(true);
            }
            HighlightButton();
            canMoveButton = false;
            Invoke("ResetCanMoveButton",canMoveButtonDelay);
        }
    }

    private void IterateIndex(bool positive) {
        selectedButton = positive ? selectedButton + 1 : selectedButton - 1;
        selectedButton = selectedButton % buttonHighlights.Count;
        if (selectedButton < 0) selectedButton += buttonHighlights.Count;
    }

    private void HighlightButton() {
        for (int i = 0; i < buttonHighlights.Count; i++) {
            if (i == selectedButton) buttonHighlights[i].SetActive(true);
            else buttonHighlights[i].SetActive(false);
        }
    }

    private void ResetCanMoveButton() {
        canMoveButton = true;
    }

    private void ActivateButton() {
        switch (selectedButton) {
            case 0:
                StartGame();
                break;
            case 1:
                ShowStory();
                break;
            case 2: 
                ShowCredits();
                break;
            case 3:
                QuitGame();
                break;
        }
    }
}
