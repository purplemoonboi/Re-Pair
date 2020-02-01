using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dg_FinalPortal : MonoBehaviour
{
    public dg_YouWin m_youWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        m_youWin.FadeInText();
    }
}
