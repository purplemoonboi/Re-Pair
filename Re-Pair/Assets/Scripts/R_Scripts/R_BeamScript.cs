using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_BeamScript : MonoBehaviour
{

    Vector3 m_cubeTransform;

    float m_xScale;
    public static bool startGrowth;
    

    // Start is called before the first frame update
    void Start()
    {
        m_cubeTransform = transform.localScale;
        m_xScale = transform.localScale.x;
        startGrowth = false;


    }

    // Update is called once per frame
    private void Update()
    {
        if (startGrowth) { Grow(); }

    }

 

    void Grow()
    {
        
        m_cubeTransform.x += 16 * Time.deltaTime;
        transform.localScale = m_cubeTransform;
    }
    public void SetGrowth()
    {
        startGrowth = true;
    }

  
}
