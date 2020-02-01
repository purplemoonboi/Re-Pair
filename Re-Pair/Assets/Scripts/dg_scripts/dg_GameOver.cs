using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dg_GameOver : MonoBehaviour
{
    public TextMeshProUGUI m_portalClosedText;
    float m_fadetime = 5.0f;
    [SerializeField] private dg_FadeToBlack m_panel;

    // Start is called before the first frame update
    private void Start()
    {
        m_portalClosedText.canvasRenderer.SetAlpha(0.0f);
    }

    public void FadeInText()
    {
        m_portalClosedText.CrossFadeAlpha(1.0f, m_fadetime, false);
        m_panel.FadeIn();
    }
}
