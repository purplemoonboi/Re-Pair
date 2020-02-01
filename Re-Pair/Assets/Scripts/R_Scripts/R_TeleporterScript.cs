using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_TeleporterScript : MonoBehaviour
{
    public Transform m_PlayerOne;
    public Transform m_PlayerTwo;
    public Transform m_reciever;
    public Transform m_camera;

    private bool m_PlayerOneIsOverlapping = false;
    private bool m_PlayerTwoIsOverlapping = false;
    private bool m_cameraIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if(m_PlayerOneIsOverlapping)
        {
            Vector3 l_portalToPlayer = m_PlayerOne.position - transform.position;
            float l_dotproduct = Vector3.Dot(transform.up, l_portalToPlayer);


            if (l_dotproduct < 0f)
            {
                float l_rotDifference = Quaternion.Angle(transform.rotation, m_reciever.rotation);
                l_rotDifference += 180;

                m_PlayerOne.Rotate(Vector3.up, l_rotDifference);

                Vector3 l_posOffset = Quaternion.Euler(0f, l_rotDifference, 0f) * l_portalToPlayer;
                m_PlayerOne.position = m_reciever.position + l_posOffset;

                m_PlayerOneIsOverlapping = false;
            }
        }
        if (m_PlayerTwoIsOverlapping)
        {
            Vector3 l_portalToPlayer = m_PlayerTwo.position - transform.position;
            float l_dotproduct = Vector3.Dot(transform.up, l_portalToPlayer);


            if (l_dotproduct < 0f)
            {
                float l_rotDifference = Quaternion.Angle(transform.rotation, m_reciever.rotation);
                l_rotDifference += 180;

                m_PlayerTwo.Rotate(Vector3.up, l_rotDifference);

                Vector3 l_posOffset = Quaternion.Euler(0f, l_rotDifference, 0f) * l_portalToPlayer;
                m_PlayerTwo.position = m_reciever.position + l_posOffset;

                m_PlayerTwoIsOverlapping = false;
            }
        }
        if (m_cameraIsOverlapping)
        {
            Vector3 l_portalTocamera = m_camera.position - transform.position;
            float l_dotproduct = Vector3.Dot(transform.up, l_portalTocamera);


            if (l_dotproduct < 0f)
            {
                float l_rotDifference = Quaternion.Angle(transform.rotation, m_reciever.rotation);
                l_rotDifference += 180;

                m_PlayerOne.Rotate(Vector3.up, l_rotDifference);

                Vector3 l_posOffset = Quaternion.Euler(0f, l_rotDifference, 0f) * l_portalTocamera;
                m_PlayerOne.position = m_reciever.position + l_posOffset;

                m_PlayerOneIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerOne" && other.tag == "PlayerTwo") 
        {
            Debug.Log("No colliding");
            m_PlayerOneIsOverlapping = true;
            m_PlayerTwoIsOverlapping = true;
            m_cameraIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "playerOne" && other.tag == "PlayerTwo") 
        {
            m_PlayerOneIsOverlapping = false;
            m_PlayerTwoIsOverlapping = false;
            m_cameraIsOverlapping = false;
        }
    }
}
