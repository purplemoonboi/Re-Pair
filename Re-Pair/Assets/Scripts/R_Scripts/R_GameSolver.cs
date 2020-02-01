using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 



[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class R_CharacterControler : MonoBehaviour
{


    [SerializeField] private Rigidbody m_rigidbody;

    [SerializeField] [Range(1, 10000)] private float m_thrust = 100f;


    [SerializeField]private Transform m_objectPosition;
    [SerializeField]private Transform m_targetPosition;

    private float m_xSpeedmin, m_xSpeedMax, m_zSpeedMin, m_zSpeedMax;
    public static float m_distance;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_xSpeedMax = 250;
        m_xSpeedmin = 100;
        m_zSpeedMax = 250;
        m_zSpeedMin = 100;
        
       if(m_targetPosition == null)
        {
            Debug.Log("Cannot find target transform");
        }
    }

    private void Update()
    {
        m_distance = CalculateDst(m_objectPosition.position, m_targetPosition.position);
        Debug.Log("Distance: " + m_distance);
    }

    void FixedUpdate()
    {
        HandleInput();
        ClampVelocity();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_thrust += 10;
            
            m_rigidbody.AddForce(0, 0 , m_thrust * Time.deltaTime, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;

        }
        if (Input.GetKey(KeyCode.S))
        {
            m_thrust += 10;
            
            m_rigidbody.AddForce(0, 0, -m_thrust * Time.deltaTime, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_thrust += 10;
            
            m_rigidbody.AddForce(-m_thrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(m_thrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        else m_thrust -= 10;

        if(m_thrust < 100)
        {
            m_thrust = 100;
        }
    }

    void ClampVelocity()
    {
        Debug.Log("Velocity " +m_rigidbody.velocity);
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
