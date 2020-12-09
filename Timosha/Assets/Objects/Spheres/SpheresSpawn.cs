using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpheresSpawn : MonoBehaviour
{
    public GameObject ShotButton;

    Cube_Control cube_Control;

    public Transform player;

    public Transform EyesPlayer;

    public GameObject smallSphere;

    public GameObject BigSphere;

    public GameObject sphereBullet;

    public float Power = 100;

    static int PoolLimit = 200;

    public List<GameObject> spheresPool = new List<GameObject>(PoolLimit);

    public List<GameObject> EnemyspheresPool = new List<GameObject>(50);

    public List<GameObject> spherebulletPool = new List<GameObject>(10);

    public static int scoreIs;

    public static int BulletCount;

    bool PoolIsFilled = false;

    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;

        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();

        scoreIs = 0;
        fillPool();
    }



    void Update()
    {
        ////////////////////////////////////////////////////////////////////////////////////       
        ///////////////////////////////////////////////////////////////////////////////////
        for (int i = 0; i < spheresPool.Count; i++)
        {
            if (spheresPool[i]==null)
            {
                scoreIs++;
                Cube_Control.speed += 0.05f;
                //cube_Control.Timosha.speed += 0.05f;
                GetComponent<AudioSource>().Play();
                spheresPool.RemoveAt(i);
            }
        }       
    }
    void fillPool()
    {
        for (int i = 0; i < PoolLimit; i++)
        {
            spheresPool.Add(Instantiate(smallSphere, player));
            spheresPool[i].transform.position = player.position +
                new Vector3(Random.Range(-50, 50), Random.Range(-7, 7), Random.Range(-50, 50));
            spheresPool[i].transform.SetParent(null);
        }

        for (int i = 0; i < 50; i++)
        {
            EnemyspheresPool.Add(Instantiate(BigSphere, player));
            EnemyspheresPool[i].transform.position = player.position +
                new Vector3(Random.Range(-50, 50), Random.Range(-15, 20), Random.Range(-50, 50))
                - new Vector3(Random.Range(-15, 15), Random.Range(-5, 12), Random.Range(-15, 15));
            EnemyspheresPool[i].transform.SetParent(null);
        }

        for (int i = 0; i < 10; i++)
        {
            spherebulletPool.Add(Instantiate(BigSphere, EyesPlayer));
            spherebulletPool[i].transform.localPosition = new Vector3(0, 0, 1);
            spherebulletPool[i].SetActive(false);
        }
    }

    IEnumerator ShotBulletPool()
    {
        for (int i = 0; i < 10; i++)
        {
            spherebulletPool[i].SetActive(true);
            spherebulletPool[i].transform.SetParent(null);

            Vector3 direction = EyesPlayer.position - LikeTarget.currentTarget;

            spherebulletPool[i].transform.
                Translate(spherebulletPool[i].transform.position - direction * Time.fixedDeltaTime*5);


            yield return new WaitForSeconds(0.5f);
        }       
    }
}
