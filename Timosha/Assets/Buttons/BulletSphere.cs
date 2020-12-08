using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSphere : MonoBehaviour
{
    public Transform player;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 50)
        {
            Destroy(this.gameObject);
        }
    }


}
