using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float capacity = 1000f;
    [SerializeField] float stored = 0f;
    [SerializeField] TMP_Text storedText;
    [SerializeField] TimerController timer;
    AudioSource vacuumAudio;
    bool finishedVacuuming = true;
    [SerializeField] int vacuumDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (storedText != null) storedText.text = StoredOverCapacity(stored,capacity);
        if (timer == null) timer = GameObject.Find("TimerController").GetComponent<TimerController>();
        vacuumAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
    }

    public void CollectDebris(float amt, bool stopAudio = false) {
        stored += amt;
        if (stored >= capacity) stored = capacity;
        if (storedText != null) storedText.text = StoredOverCapacity(stored,capacity);
        if (finishedVacuuming == true) {
            // new vacuum cycle
            finishedVacuuming = false;
            vacuumAudio.Play();
            Invoke("FinishVacuuming", vacuumDelay);
        }   
        if (stopAudio) vacuumAudio.Stop();
    }

    private void FinishVacuuming() {
        finishedVacuuming = true;
    }

    private string StoredOverCapacity(float stored, float capacity) {
        return $"{stored.ToString("0")}/{capacity.ToString("0")}";
    }

    private void CheckWin() {
        if (stored >= capacity) {
            Invoke("Victory", 3);
        }
    }

    private void Victory() {
        PlayerPrefs.SetFloat("CurrentScore", timer.GetTimeSec());
        SceneManager.LoadScene("End");
    }
}
