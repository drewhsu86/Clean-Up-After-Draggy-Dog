using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeController : MonoBehaviour
{
    [SerializeField] GameObject escPanel;
    bool escPanelActive = false;
    // Start is called before the first frame update
    void Start()
    {
        escPanel = GameObject.Find("EscPanel");
        escPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressEscape();
        ConfirmReturnToMenu();
    }

    private void CheckPressEscape() {
        if (Input.GetButtonDown("Cancel")) {
            escPanelActive = !escPanelActive;
            escPanel.SetActive(escPanelActive);
            if (Cursor.visible) Cursor.visible = false;
            else Cursor.visible = true;
            if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.Confined;
            else Cursor.lockState = CursorLockMode.Locked;
            if (Time.timeScale > 0) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void CloseMenu() {
        escPanelActive = false;
        escPanel.SetActive(escPanelActive);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    private void ConfirmReturnToMenu() {
        if (Input.GetButtonDown("Submit") && Time.timeScale == 0) {
            ReturnToMenu();
        }
    }
}
