using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject CarControls;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(CountdownToStart());
        
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }
        countdownDisplay.text = "GO!";

        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1;

        countdownDisplay.gameObject.SetActive(false);
    }

}
