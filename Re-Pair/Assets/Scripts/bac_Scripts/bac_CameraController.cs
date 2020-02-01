//Bridget A. Casey
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class bac_CameraController : MonoBehaviour
{
    public List<Transform> m_cameraTargets;

    public Vector3 m_offset;

    private float m_smoothTime = 0.5f;
    private float m_minZoom = 40f;
    private float m_maxZoom = 10f;
    private float m_zoomLimiter = 50f;

    private Vector3 m_centrePoint;
    private Vector3 m_newPosition;
    private Vector3 m_velocity;

    private Camera m_camera;

    void Start()
    {
        m_camera = GetComponent<Camera>();
        m_offset = new Vector3(0, 0, -m_zoomLimiter);
    }

    void LateUpdate()
    {
        if (m_cameraTargets.Count == 0)
        {
            return;
        }

        panCamera();
        zoomCamera();
    }

    void panCamera()
    {
        m_centrePoint = getCentrePoint();
        m_newPosition = m_centrePoint + m_offset;
        transform.position = Vector3.SmoothDamp(transform.position, m_newPosition, ref m_velocity, m_smoothTime);
    }

    void zoomCamera()
    {
        Debug.Log(getGreatestDistance());

        float l_newZoom = Mathf.Lerp(m_maxZoom, m_minZoom, getGreatestDistance() / 50f);
        m_camera.fieldOfView = Mathf.Lerp(m_camera.fieldOfView, l_newZoom, Time.deltaTime);
    }

    Bounds getEncapsulatingBounds()
    {
        Bounds l_bounds = new Bounds(m_cameraTargets[0].position, Vector3.zero);

        for (int counter = 0; counter < m_cameraTargets.Count; ++counter)
        {
            l_bounds.Encapsulate(m_cameraTargets[counter].position);
        }

        return l_bounds;
    }

    Vector3 getCentrePoint()
    {
        if (m_cameraTargets.Count == 1)
        {
            return m_cameraTargets[0].position;
        }

        Bounds l_cameraBounds = getEncapsulatingBounds();

        return l_cameraBounds.center;
    }

    float getGreatestDistance()
    {
        Bounds l_bounds = getEncapsulatingBounds();

        return Mathf.Max(l_bounds.size.x, l_bounds.size.y);
    }
}
