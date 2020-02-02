//Bridget A. Casey
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used purely to test the camera controller
public class bac_PlayerMove : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float speed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player1.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player1.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.S))
        {
            player1.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.D))
        {
            player1.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            player2.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            player2.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player2.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.Z))
        {
            player1.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.X))
        {
            player2.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
