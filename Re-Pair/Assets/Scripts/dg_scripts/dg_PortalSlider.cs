using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dg_PortalSlider : MonoBehaviour
{
    public Slider portalSlider;
    private float portalVal;
    private float maxPortal = 100;

    // Start is called before the first frame update
    void Start()
    {
        portalVal = maxPortal;
        portalSlider = GetComponent<Slider>();
        portalSlider.maxValue = maxPortal;
        portalSlider.value = portalVal;
    }

    // Update is called once per frame
    void Update()
    {
        decrementValueFromSlider();

        if (portalSlider.value == 0)
        {
            // Have some Portal Closed! UI shit pop up, i.e. (GAME OVER).
        }
    }

    public void addValueToSlider()
    {
        portalVal += 10;
        portalSlider.value = portalVal;
    }

    public void decrementValueFromSlider()
    {
        portalVal -= 0.1f;
        portalSlider.value = portalVal;
    }
}
