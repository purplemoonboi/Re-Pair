using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_PortalClosure : MonoBehaviour
{

    Vector3 m_localScale;
    private float m_localScaleX, m_localScaleZ;

    

    // Start is called before the first frame update
    void Start()
    {
        m_localScale.x = transform.localScale.x;
        m_localScale.z = transform.localScale.z;

        

        m_localScaleX = transform.localScale.x;
        m_localScaleZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        m_localScaleX -= 1 * Time.deltaTime;
        m_localScaleZ -= 1 * Time.deltaTime;
        m_localScale = new Vector3(m_localScaleX, 0, m_localScaleZ);
        transform.localScale = m_localScale;
    }

    
}
