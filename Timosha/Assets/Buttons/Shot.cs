using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject ShotButton;

    public Transform fromShot;

    public GameObject sphereBullet;

    Camera mainCamera;

    float power = 1f;

    Vector3 speed;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(ShotButton.transform.position);
        new Plane(Vector3.forward, fromShot.transform.position).Raycast(ray, out enter);
        Vector3 buttonPos = ray.GetPoint(enter);

        //speed = (buttonPos - transform.position) * power;
        speed = (buttonPos - transform.position) * power*2;
        fromShot.transform.rotation = Quaternion.LookRotation(speed);

        if (LikeTarget.WasClickOnTarget == true && SpheresSpawn.scoreIs > 0)
        {
            StartCoroutine(Shooting());
        }

        ////////////////////////////////////////////////////////////////////////////////////




    }

    IEnumerator Shooting()
    {
        Rigidbody bullet = Instantiate(sphereBullet, fromShot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //bullet.transform.localPosition = new Vector3(0, 0, 1);
        //bullet.transform.SetParent(null);
        //bullet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        bullet.AddForce(speed, ForceMode.VelocityChange);

        yield return new WaitForSeconds(3f);
    }

}
