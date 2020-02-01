using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dg_Ring : MonoBehaviour
{
    [SerializeField] private dg_PortalSlider m_slider;

    private void OnTriggerEnter(Collider other)
    {
        m_slider.addValueToSlider();
    }

    private void OnTriggerExit(Collider other)
    {
        m_slider.decrementValueFromSlider();
    }
}