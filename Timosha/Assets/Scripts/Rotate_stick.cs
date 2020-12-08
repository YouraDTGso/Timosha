using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_stick : MonoBehaviour
{
    public float rotate_button;
    public float speed_of_height = 7;
    float min_height = 2.86f;
    float max_height = 6;
    float for_cycle;

    public Transform stick_pos;
    public float speedstick = 7;
    //don't work
    void Update()
    {
        transform.Rotate(0, rotate_button * Time.fixedDeltaTime, 0);

        float offset = max_height - min_height;
        if (transform.position.y >= max_height)
        {
            transform.Translate(-Vector3.up * speedstick*Time.fixedDeltaTime);
        }
        else if (transform.position.y == min_height)
        {
            transform.Translate(Vector3.up * speedstick*Time.fixedDeltaTime);
        }
        //transform.position = Vector3.MoveTowards(transform.position, stick_pos.position, speedstick * Time.fixedDeltaTime);
        //transform.Translate(Vector3.up)
    }
}
