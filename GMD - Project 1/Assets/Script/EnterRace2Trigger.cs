using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRace2Trigger : MonoBehaviour
{

    void OnTriggerEnter()
    {
        Time.timeScale = 0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
