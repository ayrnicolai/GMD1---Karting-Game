using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject guiObject;

    private void Start()
    {
        guiObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame ()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            guiObject.SetActive(true);
        
        }
        else
        {
            Time.timeScale = 1;
            guiObject.SetActive(false);

        }
    }

    public void resetCar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

}
