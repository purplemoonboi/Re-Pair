using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerTwo : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float health;
    [SerializeField] public bool hasFinishedSplitScreen = false; //Added by Bridget
    private bool takeDamage = false;

    private float m_xSpeedmin, m_xSpeedMax, m_zSpeedMin, m_zSpeedMax, m_thrust;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();


        m_xSpeedMax = 250;
        m_xSpeedmin = 100;
        m_zSpeedMax = 250;
        m_zSpeedMin = 100;
    }

    void FixedUpdate()
    {
       
    }

    private void Update()
    {
    
     
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(0, 0, m_thrust * Time.deltaTime, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(0, 0, -m_thrust * Time.deltaTime, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(-m_thrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(m_thrust * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            if (m_thrust > 250) m_thrust = 250;
        }
        else m_thrust -= 10;

        if (m_thrust < 100)
        {
            m_thrust = 100;
        }
    }

    void ControllerInput()
    { 
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            health -= 100;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        takeDamage = false;
    }
}