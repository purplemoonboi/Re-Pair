using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; //need to install ppmanager 


[RequireComponent(typeof(Material))]
[RequireComponent(typeof(Rigidbody))]
public class R_CharacterControler : MonoBehaviour
{


    [SerializeField] private Rigidbody m_rigidbody;

    [SerializeField] private Material m_characterMaterial;
    [SerializeField] private Renderer m_characterRenderer;

    [SerializeField] [Range(2000, 10000)] private float m_thrust = 100f;

    

    private Vector3 m_objectPosition;
    private Vector3 m_targetPosition;


    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_characterMaterial = GetComponentInChildren<Material>();
        m_characterRenderer = GetComponentInChildren<Renderer>();

        m_objectPosition = transform.position;
    }


    void FixedUpdate()
    {
        HandleInput();
        ManipulateObjectEmission();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.AddForce(transform.forward * m_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.AddForce(transform.forward * -m_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidbody.AddForce(transform.right * -m_thrust * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.AddForce(transform.right * m_thrust * Time.deltaTime);
        }
    }

    private void ManipulateObjectEmission()
    {
        float l_dst = 0;

        l_dst = CalculateDst(m_objectPosition, m_targetPosition);
        if (l_dst < 30)
        {
          
        }
    }

    private float CalculateDst(Vector3 par_posOne, Vector3 par_posTwo)
    {
        float l_dst = 0;

        l_dst = (par_posOne.x - par_posTwo.x) * (par_posOne.x - par_posTwo.x) +
            (par_posOne.z - par_posTwo.z) * (par_posOne.z - par_posTwo.z);

        return l_dst;
    }

    void HandlePostProcessing()
    {

    }

}
