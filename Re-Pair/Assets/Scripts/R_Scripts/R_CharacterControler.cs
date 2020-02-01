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
    public static float m_distance;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
       

        
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
            m_rigidbody.AddForce(transform.forward * m_thrust * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.AddForce(-transform.forward * m_thrust * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidbody.AddForce(transform.right * -m_thrust * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.AddForce(transform.right * m_thrust * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    void ClampVelocity()
    {
        
       float l_velocity = Mathf.Clamp(m_rigidbody.velocity.y, 0 , 10);

        m_rigidbody.velocity.Set(m_rigidbody.velocity.x, l_velocity, m_rigidbody.velocity.z);
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
