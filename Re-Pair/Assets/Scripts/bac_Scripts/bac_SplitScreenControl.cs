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
        if (isEnterSplitScreen)
        {
            if ((isPlayerOnePortal && collider.gameObject.tag == "PlayerOne") || (isPlayerTwoPortal && collider.gameObject.tag == "PlayerTwo"))
            {
                cameraController.splitScreen(isEnterSplitScreen);
                Camera.main.GetComponent<bac_CameraController>().m_cameraTargets.Clear();
                Camera.main.GetComponent<bac_CameraController>().m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerOne").transform);
                GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<bac_CameraController>().m_cameraTargets.Clear();
                GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<bac_CameraController>().m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerTwo").transform);

                if (collider.gameObject.tag == "PlayerOne")
                {
                    Camera.main.transform.position = new Vector3(-82, -350, 262);
                    collider.gameObject.transform.position = new Vector3(-82, -400, 262);
                }

                else if (collider.gameObject.tag == "PlayerTwo")
                {
                    GameObject.FindGameObjectWithTag("SecondCamera").transform.position = new Vector3(-82, -350, 30);
                    collider.gameObject.transform.position = new Vector3(-82, -400, 30);
                }
            }

            else
            {
                Debug.Log("NO! U BAD! WRONG PORTAL!");
            }
        }

        else if(!isEnterSplitScreen)
        {
            if(collider.gameObject.tag == "PlayerOne")
            {
                GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOne>().m_hasFinishedSplitScreen = true;
                Camera.main.transform.position = new Vector3(-95, -1090, 146);
                collider.gameObject.transform.position = new Vector3(-95, -1140, 146);
            }

            else if(collider.gameObject.tag == "PlayerTwo")
            {
                GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerTwo>().m_hasFinishedSplitScreen = true;
                GameObject.FindGameObjectWithTag("SecondCamera").transform.position = new Vector3(-72, -1090, 146);
                collider.gameObject.transform.position = new Vector3(-72, -1140, 146);
            }

            if((GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOne>().m_hasFinishedSplitScreen == true) && (GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerTwo>().m_hasFinishedSplitScreen == true))
            {
                cameraController.splitScreen(false);
                Camera.main.GetComponent<bac_CameraController>().m_cameraTargets.Clear();
                Camera.main.GetComponent<bac_CameraController>().m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerOne").transform);
                Camera.main.GetComponent<bac_CameraController>().m_cameraTargets.Add(GameObject.FindGameObjectWithTag("PlayerTwo").transform);
            }
        }
    }
}
