using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Oracle_Button : MonoBehaviour
{
    public float rotate_button;
    
    void Update()
    {
        transform.Rotate(0, 0, rotate_button * Time.deltaTime);
    }
}
