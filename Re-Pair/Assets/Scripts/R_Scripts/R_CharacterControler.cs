using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 




public class R_GameSolver : MonoBehaviour
{

    [SerializeField] [Range(1, 10000)] private float m_thrust = 100f;


    [SerializeField]private Transform m_objectPosition;
    [SerializeField]private Transform m_targetPosition;

    
    public static float m_distance;

    void Start()
    { 
    }

    private void Update()
    {
        m_distance = CalculateDst(m_objectPosition.position, m_targetPosition.position);
        //Debug.Log("Distance: " + m_distance);
    }

 
    private float CalculateDst(Vector3 par_posOne, Vector3 par_posTwo)
    {
        float par_dst = Vector3.Distance(par_posOne, par_posTwo);

        return par_dst;
    }

    public static float GetDistance()
    {
        return m_distance;
    }

}
