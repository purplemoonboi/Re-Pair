//Bridget A. Casey
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class bac_CameraController : MonoBehaviour
{
    public List<Transform> m_cameraTargets;

  [SerializeField]  private float m_smoothTime = 0.5f;
    [SerializeField] private float m_minZoom = 40f;
    [SerializeField] private float m_maxZoom = 10f;
    [SerializeField] private float m_zoomLimiterY = 50f;
    [SerializeField]
 private float m_zoomLimiterZ = -23.5f;

    private bool m_checkSplit = false;

    private Vector3 m_centrePoint;
    private Vector3 m_newPosition;
    private Vector3 m_velocity;
    private Vector3 m_offset;

    public Camera m_mainCamera;
    public Camera m_secondCamera;

    private Bounds m_cameraBounds;

    void Start()
    {
        m_mainCamera = Camera.main;
        m_secondCamera = GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<Camera>();
        m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerOne").transform);
        m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerTwo").transform);
        m_offset = new Vector3(0f, m_zoomLimiterY, m_zoomLimiterZ);
    }

    void LateUpdate()
    {
        if (m_cameraTargets.Count == 0)
        {
            return;
        }

        m_cameraBounds = getEncapsulatingBounds();

        panCamera();

        if (m_cameraTargets.Count > 1)
        {
            zoomCamera();
        }

        splitScreen();
    }

    void panCamera()
    {
        m_centrePoint = getCentrePoint();
        m_newPosition = m_centrePoint + m_offset;
        transform.position = Vector3.SmoothDamp(transform.position, m_newPosition, ref m_velocity, m_smoothTime);
    }

    void zoomCamera()
    {
        float l_newZoomLimit = 0;

        if (getGreatestDistance() == m_cameraBounds.size.x)
        {
            l_newZoomLimit = m_zoomLimiterY;
        }

        else if(getGreatestDistance() == m_cameraBounds.size.z)
        {
            l_newZoomLimit = m_zoomLimiterY / 2.5f;
        }

        float l_newZoom = Mathf.Lerp(m_maxZoom, m_minZoom, getGreatestDistance() / l_newZoomLimit);
        m_mainCamera.fieldOfView = Mathf.Lerp(m_mainCamera.fieldOfView, l_newZoom, Time.deltaTime);
    }

    void splitScreen()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_checkSplit = !m_checkSplit;

            if(m_checkSplit)
            {
                if(transform.gameObject.tag == "MainCamera")
                {
                    m_cameraTargets.Clear();
                    m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerOne").transform);
                }

                else if(transform.gameObject.tag == "SecondCamera")
                {
                    m_cameraTargets.Clear();
                    m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerTwo").transform);
                }

                m_mainCamera.rect = new Rect(0, 0, 0.5f, 1f);
                m_secondCamera.gameObject.SetActive(true);
                m_secondCamera.rect = new Rect(0.5f, 0, 0.5f, 1f);
            }

            else
            {
                m_cameraTargets.Clear();
                m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerOne").transform);
                m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerTwo").transform);

                m_mainCamera.rect = new Rect(0, 0, 1f, 1f);
                m_secondCamera.gameObject.SetActive(false);
            }
        }
    }

    Bounds getEncapsulatingBounds() //Calculates and returns the bounding box containing all camera target objects
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

        return m_cameraBounds.center;
    }

    float getGreatestDistance() //Returns the greatest distance between all camera target objects
    {
        return Mathf.Max(m_cameraBounds.size.x, m_cameraBounds.size.z);
    }
}
