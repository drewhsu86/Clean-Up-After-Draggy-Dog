using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] List<GameObject> uiItems;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ClosePanels();
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
}
