using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LWRP;

[RequireComponent(typeof(Material))]

public class R_MaterialHandler : MonoBehaviour
{

    [SerializeField] private Material m_materialOne;
    [SerializeField] private Material m_materialTwo;
    [SerializeField] private R_CharacterControler m_controllerInstance;

    // Start is called before the first frame update
    private void Start()
    {
        m_materialOne.SetFloat("_GlowOne", 1);
        m_materialTwo.SetFloat("_Glow", 1);
    }

    private void Update()
    {
        ManipulateObjectEmission();
    }


    private void ManipulateObjectEmission()
    {

        float l_dst = R_CharacterControler.GetDistance();
       

        Mathf.Clamp(l_dst, 1, 10);

        m_materialOne.SetFloat("_GlowOne", l_dst);
        m_materialTwo.SetFloat("_Glow", l_dst);
       
    }
}
