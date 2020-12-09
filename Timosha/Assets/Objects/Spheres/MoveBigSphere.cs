using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBigSphere : MonoBehaviour
{
    public Material solidSphere;

    public Material SpaceSphere;

    public Transform player;

    Vector3 targetUp;
    Vector3 targetDown;

    bool startMoving;
    float speed;

    void Start()
    {
        startMoving = true;
        speed = Random.Range(-3f, 3f);
        targetUp = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        targetDown = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraBackgoundColor.SpaceSky==true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = SpaceSphere;
        }
        else if (CameraBackgoundColor.SpaceSky == false)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = solidSphere;
        }

        MovingSlowly();
    }

    void MoveWhenPlayerIsNear()
    {
        transform.position =
            Vector3.LerpUnclamped(transform.position, player.position, speed * Time.fixedDeltaTime);
    }

    void MovingSlowly()
    {
        if (startMoving==true)
        {
            transform.position =
            Vector3.Lerp(transform.position, targetUp, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, targetUp)<1)
            {
                startMoving = false;
            }
        
        }

        else if (startMoving == false)
        {
            transform.position =
            Vector3.Lerp(transform.position, targetDown, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, targetDown) < 1)
            {
                startMoving = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spherebullet")
        {
            transform.localScale =
                new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f,
                transform.localScale.z - 0.1f);
        }
        if (transform.localScale.x < 0.3f)
        {
            Destroy(this.gameObject);
        }
    }

}


