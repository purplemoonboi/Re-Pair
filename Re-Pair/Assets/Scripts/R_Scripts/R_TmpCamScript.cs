using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_TmpCamScript : MonoBehaviour
{

    private Quaternion rot;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rot = Quaternion.Euler(80, 0, 0);
        offset = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position = offset;
        transform.rotation = rot;
    }
}
