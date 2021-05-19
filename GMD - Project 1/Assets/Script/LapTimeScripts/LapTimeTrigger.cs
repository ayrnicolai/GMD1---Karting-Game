using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTimeTrigger : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject LapTrig;

    private void OnTriggerEnter(Collider other)
    {
        LapCompleteTrig.SetActive(true);
        LapTrig.SetActive(false);
    }

}
