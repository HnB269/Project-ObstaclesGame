using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject gameOverPanel;
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();


    // Start is called before the first frame update
    void Start()
    {
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundrethsDecimal, "0.00");

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
        if (currentTime <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timerFormats[format]) : currentTime.ToString();
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethsDecimal
}
