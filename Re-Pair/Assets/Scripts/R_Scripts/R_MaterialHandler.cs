using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LWRP;



public class R_MaterialHandler : MonoBehaviour
{

    [SerializeField] private Material m_materialOne;
    [SerializeField] private Material m_materialTwo;
   

    // Start is called before the first frame update
    private void Start()
    {
        m_materialOne.SetFloat("_intensity", 1);
        m_materialTwo.SetFloat("_intensity", 1);
    }

    private void Update()
    {
        ManipulateObjectEmission();
    }


    private void ManipulateObjectEmission()
    {

        float l_dst = R_GameSolver.GetDistance();

        
        

        m_materialOne.SetFloat("_intensity", l_dst);
        m_materialTwo.SetFloat("_intensity", l_dst);
       
    }
}
