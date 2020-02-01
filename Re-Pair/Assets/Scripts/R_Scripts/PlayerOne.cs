using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{

    [SerializeField] private float health;
    private bool takeDamage = false;

    private void Update()
    {
        if(takeDamage)
        {
           
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage" )
        {
            health -= 100;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        takeDamage = false;
    }
}
