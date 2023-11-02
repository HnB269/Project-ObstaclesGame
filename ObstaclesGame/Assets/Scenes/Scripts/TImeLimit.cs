using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TImeLimit : MonoBehaviour
{

    float currentTime = 0f;
    public float startingTime = 10f;
    public TextMeshProUGUI countDownText;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = "Remaining Time : " + currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
