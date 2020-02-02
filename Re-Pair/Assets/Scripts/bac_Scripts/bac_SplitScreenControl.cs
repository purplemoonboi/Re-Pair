using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bac_SplitScreenControl : MonoBehaviour
{
    public bool isEnterSplitScreen;
    public bool isPlayerOnePortal;
    public bool isPlayerTwoPortal;
    bac_CameraController cameraController;

    void Start()
    {
        cameraController = FindObjectOfType<bac_CameraController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerOne" || collider.gameObject.tag == "PlayerTwo")
        {
            if ((isPlayerOnePortal && collider.gameObject.tag == "PlayerOne") || (isPlayerTwoPortal && collider.gameObject.tag == "PlayerTwo"))
            {
                this.gameObject.GetComponent<Collider>().enabled = false;
                cameraController.splitScreen(isEnterSplitScreen);
            }

            else
            {
                Debug.Log("NO! U BAD! WRONG PORTAL!");
            }
        }
    }
}
