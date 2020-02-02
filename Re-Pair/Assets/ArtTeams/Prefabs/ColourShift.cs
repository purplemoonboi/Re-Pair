using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourShift : MonoBehaviour
{
 
    void Start()
    {
     
        //Material mymat = GetComponent<Renderer>().material;
        //    mymat.SetColor("_EmissionColor", Color.red);
        StartCoroutine("Update");
    }

    // Update is called once per frame
    IEnumerable Update()
    {
        Material mymat = GetComponent<Renderer>().material;
        mymat.SetColor("_EmissionColor", Color.HSVToRGB(1f, 1f, 1f));
        yield return new WaitForSeconds(5);

    }
}
