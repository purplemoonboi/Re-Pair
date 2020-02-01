using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dg_Ring : MonoBehaviour
{
    [SerializeField] private dg_PortalSlider slider;

    private void OnTriggerEnter(Collider other)
    {
        slider.addValueToSlider();
        print("Setting true");
    }

    private void OnTriggerExit(Collider other)
    {
        slider.decrementValueFromSlider();
        print("Setting false");
    }
}