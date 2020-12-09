using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSmallSphere : MonoBehaviour
{
    public Transform player;

    float speed=6;


    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.LookAt(player);
        if (Vector3.Distance(player.position, transform.position)<=7)
        {
            MoveWhenPlayerIsNear();
        }
    }

    void MoveWhenPlayerIsNear()
    {
        transform.position = 
            Vector3.Slerp(transform.position, player.position, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
}
