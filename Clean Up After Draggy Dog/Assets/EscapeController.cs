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
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressEscape();
    }

    private void CheckPressEscape() {
        if (Input.GetButtonDown("Cancel")) {
            escPanelActive = !escPanelActive;
            escPanel.SetActive(escPanelActive);
            if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.Confined;
            else Cursor.lockState = CursorLockMode.Locked;
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
    }
}
