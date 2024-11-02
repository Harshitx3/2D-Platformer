using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishpoint : MonoBehaviour
{
   // [SerializeField] bool goNextLevel;
   // [SerializeField] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scenecontroller.instance.NextLevel();

            UNlocklevel();
                
        
        }
    }


    void UNlocklevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Reachedindex"))
        {
            PlayerPrefs.SetInt("Reavhedindex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();

        }
    }
}
