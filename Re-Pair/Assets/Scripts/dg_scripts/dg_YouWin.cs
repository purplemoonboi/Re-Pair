using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dg_YouWin : MonoBehaviour
{
    public TextMeshProUGUI m_congratulations;
    float m_fadetime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_congratulations.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeInText()
    {
        print("Fade called");
        m_congratulations.CrossFadeAlpha(1.0f, m_fadetime, false);
    }
}
