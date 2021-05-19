using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Car_Radio : MonoBehaviour
    {

        public AudioClip[] myClips;
        private int currentClip;
        private int currentTexts;
        public GameObject GUIRadio;


        // Use this for initialization
        void Start()
        {
            GetComponent<AudioSource>().clip = myClips[0];
            GUIRadio.SetActive(true);


        // initialize Audio Clip to 0th clip from the array

    }

    // Update is called once per frame
    void Update()
        {

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GUIRadio.SetActive(false);
                GetComponent<AudioSource>().clip = myClips[currentClip];
                GetComponent<AudioSource>().Play();


                currentClip++;
                if (currentClip == myClips.Length)
                    currentClip = 0;
            }

        }
    }

