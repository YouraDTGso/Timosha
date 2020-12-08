using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_of_beams_down : MonoBehaviour
{
    

    public float speed = 10;

    private void Update()
    {
        if (transform.position.y<-0.41f)
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        } 
        else if (transform.position.y >= -0.41f)
        {
            speed = 0;
            transform.Translate(Vector3.up*0);
            transform.position=new Vector3(transform.position.x, -0.41f, transform.position.z);
        }
    }

    

}
