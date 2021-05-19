using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public Rigidbody target;
    private int currentClip;
//   private int currentEngine;
    public AudioClip[] audioData;
//    public AudioClip[] EngineSound;





    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = audioData[0];
     //   GetComponent<AudioSource>().clip = EngineSound[0];


    }

    // Update is called once per frame
    void Update()
    {
   //     playAudio();
   //     KPH = target.velocity.magnitude * 1f;



    }

    //void playAudio()
    //{
    //    if (KPH <= 1)
    //    {
    //        GetComponent<AudioSource>().clip = EngineSound[0];
    //        GetComponent<AudioSource>().Play();
    //        Debug.Log(123213);

    //    }
    //    else if (KPH >= 1)
    //    {
    //        GetComponent<AudioSource>().clip = EngineSound[1];
    //        GetComponent<AudioSource>().Play();
    //        Debug.Log("sdfjufsdf");

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().clip = audioData[currentClip];
        GetComponent<AudioSource>().Play();


    }
  

}
