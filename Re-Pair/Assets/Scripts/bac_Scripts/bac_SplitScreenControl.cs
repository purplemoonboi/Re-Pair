using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bac_SplitScreenControl : MonoBehaviour
{
    bac_CameraController cameraController;

    void Start()
    {
        cameraController = FindObjectOfType<bac_CameraController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerOne" && collider.gameObject.tag == "PlayerTwo")
        {
            cameraController.splitScreen();
        }
    }
}
