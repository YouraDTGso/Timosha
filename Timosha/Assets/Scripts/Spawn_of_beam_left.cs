/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_of_beam_left : MonoBehaviour
{
    //WayTurn wayTurn;
    Cube_Control cube_Control;
    public float speed = 10;

    public void Awake()
    {
        //wayTurn = GameObject.Find("Way_of_turn").GetComponent<WayTurn>();
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "tag1" || other.tag == "tag3" || other.tag == "tag0" || other.tag == "tag2")
        {
            speed = 0;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //cube_Control.moveInBezier = true;
            //wayTurn.SamTriggerIs = true;
            //cube_Control.moveInWay = true;
        }
    }


}
*/