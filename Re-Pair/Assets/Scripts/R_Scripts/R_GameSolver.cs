using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 




public class R_GameSolver : MonoBehaviour
{

    


    private PlayerOne this_m_playerOneRef;

    private PlayerTwo this_m_playerTwoRef;

    private R_BeamScript beamRef;

    [SerializeField]private Transform m_objectPosition;
    [SerializeField]private Transform m_targetPosition;

    
    private static float m_distance;
    private static float m_score = 0;

    void Start()
    {
        m_objectPosition.position = this_m_playerOneRef.transform.position;
        m_targetPosition.position = this_m_playerTwoRef.transform.position;

    }

    private void Update()
    {
        m_distance = CalculateDst(m_objectPosition.position, m_targetPosition.position);

        m_score += 10 * Time.deltaTime;
        if(m_distance < 3)
        {
            m_score += 40 * Time.deltaTime;
            this_m_playerOneRef.IncrimentHealth();
            this_m_playerTwoRef.IncrimentHealth();
            Debug.Log("SCORE X3 " + m_score);
        }
        else if(m_score < 7)
        {
            m_score += 60 * Time.deltaTime;
            Debug.Log("SCORE X7 " + m_score);
        }

        Debug.Log("Distance: " + m_distance);
        Debug.Log("SCORE " + m_score);
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

    public static float GetScore()
    {
        return m_score;
    }

    private void OnTriggerEnter(Collider other)
    {
        other = FindObjectOfType<TorusObj>().GetComponent<Collider>();

        if(other.tag == "playerOne" && other.tag == "PlayerTwo")
        {
            beamRef.SetGrowth();
        }
    }

}
