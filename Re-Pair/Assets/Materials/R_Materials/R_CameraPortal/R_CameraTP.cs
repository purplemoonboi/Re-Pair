using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_CameraTP : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform m_portalA;
    [SerializeField] private Transform m_portalB;

    // Update is called once per frame
    void Update()
    {
        CalculateAngularDifferenceCameraA();
        CalculateAngularDifferenceCameraB();
    }

    void CalculateAngularDifferenceCameraA()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - m_portalA.position;

        transform.position = m_portalA.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(m_portalA.rotation, m_portalB.rotation);

        Quaternion portalRotDiffernce = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCameraDir = portalRotDiffernce * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);

    }

    void CalculateAngularDifferenceCameraB()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - m_portalB.position;

        transform.position = m_portalA.position + playerOffsetFromPortal;

        float angularDifference = Quaternion.Angle(m_portalA.rotation, m_portalB.rotation);

        Quaternion portalRotDiffernce = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCameraDir = portalRotDiffernce * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
    }
}
