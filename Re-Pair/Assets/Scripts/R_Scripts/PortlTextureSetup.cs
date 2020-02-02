using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortlTextureSetup : MonoBehaviour
{

    public Camera cameraA;
    public Camera cameraB;
    public Camera cameraC;


    public Material cameraAMaterial;
    public Material cameraBMaterial;
    public Material cameraCMaterial;


    // Start is called before the first frame update
    void Start()
    {
        if(cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        if (cameraC.targetTexture != null)
        {
            cameraC.targetTexture.Release();
        }



        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.width, 24);
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.width, 24);
        cameraC.targetTexture = new RenderTexture(Screen.width, Screen.width, 24);


        cameraAMaterial.mainTexture = cameraA.targetTexture;
        cameraBMaterial.mainTexture = cameraB.targetTexture;
        cameraBMaterial.mainTexture = cameraB.targetTexture;
    }

  
}
