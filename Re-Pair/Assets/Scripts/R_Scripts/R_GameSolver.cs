using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 




public class R_GameSolver : MonoBehaviour
{

    


    private PlayerOne this_m_playerOneRef;

    private PlayerTwo this_m_playerTwoRef;

    [SerializeField]private Transform m_objectPosition;
    [SerializeField]private Transform m_targetPosition;

    
    private static float m_distance;

    void Start()
    {
        m_objectPosition.position = this_m_playerOneRef.transform.position;
        m_targetPosition.position = this_m_playerTwoRef.transform.position;

    }

    private void Update()
    {
        m_distance = CalculateDst(m_objectPosition.position, m_targetPosition.position);
        Debug.Log("Distance: " + m_distance);
    }

 
    private float CalculateDst(Vector3 par_posOne, Vector3 par_posTwo)
    {
        float par_dst = Vector3.Distance(par_posOne, par_posTwo);
        Debug.Log("Dist" + par_dst);
        return par_dst;
    }

    public static float GetDistance()
    {
        return m_distance;
    }

}
