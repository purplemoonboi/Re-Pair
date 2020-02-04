using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerTwo : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] [Range(1, 10000)] private float m_thrust = 100f;
    [SerializeField] private float m_acceleration;
    [SerializeField] private float m_maxAcceleration;
    [SerializeField] private float m_rateOfChange;
    [SerializeField] private float m_thrustPower;
    [SerializeField] private float m_thrustMax;
    [SerializeField] private float m_thrustDecline;
    [SerializeField] private Rigidbody m_rigidbody;

    [Header("Health")]
    [SerializeField] private int m_health;
    [SerializeField] private int m_incrimentedHealthValue;
    private bool m_takeDamage = false;

    [Header("Trail Renderer")]
    [SerializeField] private TrailRenderer m_playerOneTrailRenderer;

    [Header("Splitscreen Boolean")]
    public bool m_hasFinishedSplitScreen = false; //Added by Bridget





    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_playerOneTrailRenderer = GetComponent<TrailRenderer>();
        m_health = 500;
    }

    private void Update()
    {
        AcceleratePlayer();
        TrailRenderer();
    }

    void FixedUpdate()
    {
        HandleInput();
    }


    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_thrust += m_thrustPower;

            m_rigidbody.AddForce(m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > m_thrustMax) m_thrust = m_thrustMax;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_thrust += m_thrustPower;

            m_rigidbody.AddForce(-m_thrust * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            if (m_thrust > m_thrustMax) m_thrust = m_thrustMax;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_thrust += m_thrustPower;

            m_rigidbody.AddForce(0, 0, m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > m_thrustMax) m_thrust = m_thrustMax;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_thrust += m_thrustPower;

            m_rigidbody.AddForce(0, 0, -m_thrust * Time.deltaTime, ForceMode.Acceleration);
            if (m_thrust > m_thrustMax) m_thrust = m_thrustMax;
        }
        m_thrust -= m_thrustDecline;

        if (m_thrust < 300)
        {
            m_thrust = 300;
        }
    }

    private void AcceleratePlayer()
    {
        m_acceleration += 18;
        transform.Translate(-m_acceleration * Time.deltaTime, 0, 0);
        if (m_acceleration > m_maxAcceleration) m_acceleration = m_maxAcceleration;
    }

    public void IncrimentHealth()
    {
        m_health += 25;
    }

    private void TrailRenderer()
    {
        // if (m_acceleration == 24) { m_playerOneTrailRenderer.endColor = Color.green; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            m_health -= 100;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        m_takeDamage = false;
    }
}
