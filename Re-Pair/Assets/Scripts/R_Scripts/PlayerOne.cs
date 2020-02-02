using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerOne : MonoBehaviour
{
    PlayerControls gamepadInput;

    [SerializeField] [Range(1, 10000)] private float m_thrust = 100f;
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private float health;
    [SerializeField] public bool hasFinishedSplitScreen = false; //Added by Bridget
    private bool takeDamage = false;

    private float m_xSpeedmin, m_xSpeedMax, m_zSpeedMin, m_zSpeedMax;
   

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
      //  gamepadInput = new PlayerControls();

        m_xSpeedMax = 250;
        m_xSpeedmin = 100;
        m_zSpeedMax = 250;
        m_zSpeedMin = 100;


   
    }

    private void Update()
    {
        transform.Translate(0, -30 * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        HandleInput();
       // ControllerInput();
    }


    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_thrust += 125;

            m_rigidbody.AddForce(0, 0, m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > 900) m_thrust = 900;

        }
        if (Input.GetKey(KeyCode.S))
        {
            m_thrust += 125;

            m_rigidbody.AddForce(0, 0, -m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > 900) m_thrust = 900;
        }
        if (Input.GetKey(KeyCode.A))
        {
           m_thrust += 125;

            m_rigidbody.AddForce(-m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > 900) m_thrust = 900;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_thrust += 125;

            m_rigidbody.AddForce(m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > 900) m_thrust = 900;
        }
         m_thrust -= 75;

        if (m_thrust < 300)
        {
            m_thrust = 300;
        }
    }

    void ControllerInput()
    {
      //  gamepadInput.Gameplay.LeftMovement.performed += ctx => m_rigidbody.AddForce(0, 0, m_thrust * Time.deltaTime, ForceMode.VelocityChange);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage" )
        {
            health -= 100;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        takeDamage = false;
    }
}
