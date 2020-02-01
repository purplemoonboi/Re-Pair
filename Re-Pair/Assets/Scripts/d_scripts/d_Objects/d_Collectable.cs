using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_Collectable : MonoBehaviour
{
    [Range(0, 100)] public float m_rotationSlider;

    void Update()
    {
        rotateObject(m_rotationSlider);
    }

    private void rotateObject(float value)
    {
        this.gameObject.transform.Rotate(0, value * Time.deltaTime, 0);
    }
}