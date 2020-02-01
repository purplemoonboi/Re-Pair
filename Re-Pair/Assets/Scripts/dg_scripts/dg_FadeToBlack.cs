using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dg_FadeToBlack : MonoBehaviour
{
    public Image m_fadeToBlack;

    private void Start()
    {
        m_fadeToBlack.GetComponent<CanvasRenderer>().SetAlpha(0);
    }

    public void FadeIn()
    {
        m_fadeToBlack.CrossFadeAlpha(1, 3.0f, false);
    }
}