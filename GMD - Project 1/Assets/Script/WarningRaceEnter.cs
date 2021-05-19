using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningRaceEnter : MonoBehaviour
{
    public GameObject GUIRaceWarning;

    private void Start()
    {
        GUIRaceWarning.gameObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        GUIRaceWarning.gameObject.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        GUIRaceWarning.gameObject.SetActive(false);

    }
}
