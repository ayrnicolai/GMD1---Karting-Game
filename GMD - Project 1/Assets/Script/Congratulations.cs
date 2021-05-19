using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    public GameObject CongratulationsMessage;
    public int countdownTime;


    // Start is called before the first frame update
    void Start()
    {
        CongratulationsMessage.gameObject.SetActive(true);
        StartCoroutine(CountdownToStart());

    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            CongratulationsMessage.gameObject.SetActive(true);

            countdownTime--;
        }

        yield return new WaitForSeconds(3f);


        CongratulationsMessage.gameObject.SetActive(false);
    }

}
