using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortlTextureSetup : MonoBehaviour
{

    public Camera cameraA;
    


    public Material cameraAMaterial;
    

    // Start is called before the first frame update
    void Start()
    {
        if(cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
          
        }
      


        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.width, 24);
       

        cameraAMaterial.mainTexture = cameraA.targetTexture;
        
    }

  
}
