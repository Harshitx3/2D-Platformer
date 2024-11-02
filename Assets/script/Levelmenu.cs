using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelmenu : MonoBehaviour
{
    public Button[] button;


    private void Awake()
    {
        int unlockedlevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i = 0; i <button.Length; i++)
        {
            button[i].interactable = false;
        }

        for (int i = 0; i<unlockedlevel; i++)
        {
            button[i].interactable = true;
        }
    }
    public void Openlevel(int levelid)
    {
        string levelname = "Level" +" "+ levelid;
        SceneManager.LoadScene(levelname);
    }
}
