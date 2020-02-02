using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dg_PortalSlider : MonoBehaviour
{
    public Slider m_portalSlider;
    public dg_GameOver m_gameOverText;
    private R_PortalClosure m_portalClosureRef;
    private float m_portalVal;
    private float m_maxPortal = 100;

    // Start is called before the first frame update
    void Start()
    {
        
        m_portalVal = m_maxPortal;
        m_portalSlider = GetComponent<Slider>();
        m_portalSlider.maxValue = m_maxPortal;
        m_portalSlider.value = m_portalVal;
    }

    // Update is called once per frame
    void Update()
    {
        decrementValueFromSlider();

        if (m_portalSlider.value == 0)
        {
            // Have some Portal Closed! UI shit pop up, i.e. (GAME OVER).
            m_gameOverText.FadeInText();
        }
    }

    public void addValueToSlider()
    {
        m_portalVal += 100 * Time.deltaTime;
        m_portalSlider.value = m_portalVal;
    }

    public void decrementValueFromSlider()
    {
        m_portalVal -= 3.0f * Time.deltaTime;
        m_portalSlider.value = m_portalVal;
    }
}
