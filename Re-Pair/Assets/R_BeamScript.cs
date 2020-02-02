using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_BeamScript : MonoBehaviour
{

    Vector3 m_cubeTransform;

    float m_xScale;

    

    // Start is called before the first frame update
    void Start()
    {
        m_cubeTransform = transform.localScale;
        m_xScale = transform.localScale.x;

        
    }

    // Update is called once per frame
    private void Update()
    {
        Grow();
    }

 

    void Grow()
    {
        
        m_cubeTransform.x += 16 * Time.deltaTime;
        transform.localScale = m_cubeTransform;
    }

  
}
