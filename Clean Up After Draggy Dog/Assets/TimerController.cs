using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] float currentSec = 0f;
    [SerializeField] TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSec += Time.deltaTime;
        SetTimerText();
    }

    private void SetTimerText() {
        TimeSpan t = TimeSpan.FromSeconds(currentSec);
        if (timerText != null) timerText.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
    }
}
