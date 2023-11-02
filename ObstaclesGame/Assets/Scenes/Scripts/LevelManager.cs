using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelButtons;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("levelUnlocked")==0)
        {
            PlayerPrefs.SetInt("levelUnlocked", 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = true;
        }
        for(int i =1;i<=PlayerPrefs.GetInt("levelUnlocked");i++)
        {
            levelButtons[i - 1].GetComponent<Button>().interactable = true;
        }
    }

    public void loadscene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
