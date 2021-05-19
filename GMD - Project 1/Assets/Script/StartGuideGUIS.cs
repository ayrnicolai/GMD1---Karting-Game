using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGuideGUIS : MonoBehaviour
{

    public GameObject StartGUI1;
    public GameObject StartGUI2;
    private int lastPressed = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartGUI1.SetActive(true);
        StartGUI2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(lastPressed != 1)
            {
                StartGUI1.SetActive(false);
                StartGUI2.SetActive(true);
                lastPressed = 1;
            } else
            {
                StartGUI2.SetActive(false);
                

            }
           
        }
    }
}
