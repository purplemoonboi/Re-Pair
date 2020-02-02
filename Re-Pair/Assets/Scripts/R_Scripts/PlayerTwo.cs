using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerTwo : MonoBehaviour
{
    [SerializeField] [Range(1, 10000)] private float m_thrust = 100f;
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float health;
    [SerializeField] public bool hasFinishedSplitScreen = false; //Added by Bridget
    private bool takeDamage = false;

    private float m_xSpeedmin, m_xSpeedMax, m_zSpeedMin, m_zSpeedMax;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();


        m_xSpeedMax = 150;
        m_xSpeedmin = 80;
        m_zSpeedMax = 150;
        m_zSpeedMin = 80;

       
    }

    private void LateUpdate()
    {
        transform.Translate(0, -30 * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    private void Update()
    {
    
     
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(0, 0, m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > 150)m_thrust = 150;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(0, 0, -m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > 150) m_thrust = 150;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(-m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > 150) m_thrust = 150;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_thrust += 10;

            m_rigidbody.AddForce(m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > 150) m_thrust = 150;
        }
        else m_thrust -= 10;

        if (m_thrust < 80)
        {
            m_thrust = 80;
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