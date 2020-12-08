using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Control : MonoBehaviour
{
    #region VARIABLES

    //WayTurn wayTurn;
    //Check_tag check_Tag;
    //BezierTurn bezierTurn;
    PauseMenu pauseMenu;
    //Spawn_of_beam_right spawn_Of_Beam_Right;
    //Spawn_of_beam_left spawn_Of_Beam_Left;
    Animator camera_here;
    Quaternion originRotation;
    int q = 1;

    //Animator Run_in_game;//don't delete!
    
    protected internal Animator Timosha;

    public bool cameraOnPosition;
    //Field Of View Menu
    int fieldOfViewMenu = 50;
    int fieldOfViewGame = 60;


    //public bool Wbutton;
    public static float speed=6;    

    public bool button_was_rights;
    public bool button_was_lefts;
    public bool button_was_up;
    public bool button_was_down;

    //public bool OnCenter;
    //public bool moveInWay;
    //public bool moveOutWay;

    //public bool moveInBezier;
    //public bool moveOutBezier;

    //public bool readyForBezierRight;
    //public bool readyForBezierLeft;

    public bool playButtonWas;
    //int nextPointIndex = 10;

    //For coroutine

    //BezierStaticForBeams bezierStaticForBeams;
    //public Transform pointPrefab;
    //protected internal Transform pointAngleFromSam;
    //[SerializeField]

    //protected internal GameObject[] routes=new GameObject[1];

    //int routeToGo;
    //[SerializeField]
    //protected internal float tParam;
    //public float speedModifier;
    //bool coroutineAllowed;
    //Vector3 cubePosition;

    //internal Vector3 pointFromSam;

    //internal Vector3 pointAngleFromSam;

    //internal Vector3 pointAngleFromBeam;

    //internal Vector3 pointFromBeam;

    //protected internal bool ForCoroutine;

    //For Alternative turn to right or left

    //Quaternion currentAngle;
    //Quaternion targetAngle;

    //Quaternion targetAngle_90;

    //Quaternion curAngle;
    //Quaternion tarAngle;

    #endregion
    void Awake()
    {
        //wayTurn = GameObject.Find("Way_of_turn").GetComponent<WayTurn>();
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
        //Check_tag check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();
        //bezierTurn = GameObject.Find("BezierOfTurn").GetComponent<BezierTurn>();

        //Run_in_game = GameObject.Find("Sam").GetComponent<Animator>();//don't delete!
        Timosha = GetComponent<Animator>();

        button_was_rights = false;
        button_was_lefts = false;
        button_was_down = false;
        button_was_up = false;

        //OnCenter = false;
        //moveInWay = false;
        //moveOutWay = false;

        //moveInBezier = false;
        //moveOutBezier = true;

        //readyForBezierRight = false;
        //readyForBezierLeft = false;

        cameraOnPosition = false;
        

        //Wbutton = false;
        originRotation = transform.rotation;
        playButtonWas = false;

        //For coroutine

        //routeToGo = 0;
        //tParam = 0f;
        //speedModifier = 0.07f;
        //coroutineAllowed = true;

        //ForCoroutine = false;

        //For Alternative turn to right or left

        //currentAngle = transform.rotation;

        //curAngle = transform.rotation;
    }

    void Update()
    {

        //set field of view of main camera equal 50 in menu
        if (camera_here.GetBool("cb") == false) 
        {
            StartCoroutine(cameraToMenu());
        }
        
        else if (camera_here.GetBool("cb") == true)
        {
            if (CameraBackgoundColor.SpaceSky == true)
            {
                camera_here.SetBool("st", true);
                camera_here.SetBool("df", false);
            }
            else if (CameraBackgoundColor.SpaceSky == false)
            {
                camera_here.SetBool("st", false);
                camera_here.SetBool("df", true);
            }


            //set field of view of main camera equal 50 in game
            StartCoroutine(cameraToGame());

            playButtonWas = true;
            Timosha.SetFloat("run", 1.0f, 0.1f, Time.fixedDeltaTime);

            /*
            if (Input.GetKey(KeyCode.W) && (pauseMenu.pauseWas==false))// temporary block of code
            {
                //Run_in_game.SetFloat("Speed_in_three", 1.0f);//don't delete!
                //transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime);        
                //Debug.Log(check_Tag.beams[check_Tag.beams.Count - 1].transform.GetChild(1).transform.position);
                //Timosha.SetBool("Idle", false);
                //WbuttonFunc();
                cameraOnPosition = true;
                transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
                Timosha.SetFloat("run", 1.0f, 0.1f, Time.fixedDeltaTime);
            }

            //Turn on bezier way end
            if (Input.GetKey(KeyCode.S))// temporary block of code
            {
                //Run_in_game.SetFloat("Speed_in_three", 1.0f);
                transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime);
            }

            if (Input.GetKey(KeyCode.D))// temporary block of code
            {
                //Run_in_game.SetFloat("Speed_in_three", 1.0f);
                transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            }

            if (Input.GetKey(KeyCode.A))// temporary block of code
            {
                //Run_in_game.SetFloat("Speed_in_three", 1.0f);
                transform.Translate(-Vector3.right * speed * Time.fixedDeltaTime);
            }
            //Turns are worked by swipe
            if ((button_was_rights == true && button_was_lefts == false))
            {
                turn_of_right();
            }
            
            if ((button_was_lefts == true && button_was_rights == false))
            {
                turn_of_left();
            }
            */
        }
    }

    //turn to right
    public void turn_of_right()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, Vector3.up);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            //readyForBezierRight = false;
            button_was_rights = false;
            q = 0;
        }
    }
    //turn to left
    public void turn_of_left()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, -Vector3.up);
        transform.rotation = originRotation*rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            //readyForBezierLeft = false;
            button_was_lefts = false;
            q = 0;
        }     
    }
    IEnumerator cameraToMenu()
    {
        while (Camera.main.fieldOfView >= fieldOfViewMenu)
        {
            Camera.main.fieldOfView -= 0.05f;
            yield return new WaitForSeconds(0.2f);
        }
        Camera.main.fieldOfView = fieldOfViewMenu;
        yield return null;
    }
    IEnumerator cameraToGame()
    {
        while (Camera.main.fieldOfView <= fieldOfViewGame)
        {
            Camera.main.fieldOfView += 0.05f;
            yield return new WaitForSeconds(0.2f);
        }
        Camera.main.fieldOfView = fieldOfViewGame;
        yield return null;
    }
    
    //For Alternative turn to right or left

    //Turn to right

    /*
    public void turn_of_right_Alter()
    {
        currentAngle.y = transform.rotation.eulerAngles.y;
        Mathf.FloorToInt(currentAngle.y);
        targetAngle_90 = Quaternion.Euler(0, currentAngle.y + 90, 0);
        Mathf.FloorToInt(targetAngle.y);

        readyForBezierRight = false;
        button_was_rights = false;      
    }

    //Turn to left
    public void turn_of_left_Alter()
    {
        currentAngle.y = transform.rotation.eulerAngles.y;
        Mathf.FloorToInt(currentAngle.y);
        targetAngle_90 = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 90, 0);
        Mathf.FloorToInt(targetAngle.y);

        readyForBezierLeft = false;
        button_was_lefts = false;
    }

    //Alternative turn for courotine

    public void turn_of_right_corout()
    {
        //transform.rotation=Quaternion.Euler(tr)

        readyForBezierRight = false;
        button_was_rights = false;
    }

    //Turn to left
    public void turn_of_left_corout()
    {
        tarAngle = Quaternion.Euler(0, curAngle.y + 90, 0);
        //tarAngle = curAngle;
        //tarAngle.y += 90;

        readyForBezierLeft = false;
        button_was_lefts = false;
    }

    protected internal void FollowOnWay()
    {
        Vector3 direction = pointFromBeam - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, tParam);
    }

    //Follow On Way

    public IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        pointFromSam = GameObject.Find("pointFromSam").transform.position;

        pointAngleFromSam = GameObject.Find("pointAngleFromSam").transform.position;

        pointAngleFromBeam = GameObject.Find("pointAngleFromBeam").transform.position;
        
        pointFromBeam = GameObject.Find("pointFromBeam").transform.position;

        Vector3 direction = pointFromBeam - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, tParam*5);

        //Debug.Log("Distance between cube and target -" +
        //        Vector3.Distance(pointFromBeam, transform.position));

        while (tParam < 1)
        {
            tParam += Time.fixedDeltaTime * speedModifier;

            cubePosition = Mathf.Pow(1 - tParam, 3) * pointFromSam +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * pointAngleFromSam +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * pointAngleFromBeam +
                Mathf.Pow(tParam, 3) * pointFromBeam;

            //Vector3 direction = pointFromBeam - transform.position;

            //Quaternion rotation = Quaternion.LookRotation(direction);            

            transform.position = Vector3.Lerp
                (transform.position, cubePosition, tParam);

            //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, tParam);

            yield return new WaitForEndOfFrame();
        }
        //Debug.Log("Distance between cube and target -" + 
        //        Vector3.Distance(pointFromBeam, transform.position));

        //transform.rotation=transform.rotation;
        //ForCoroutine = false;
        //routeToGo += 1;

        //if (routeToGo > routes.Length - 1)
        //    routeToGo = 0;
        //coroutineAllowed = true;
        ForCoroutine = false;
        readyForBezierLeft = false;
        readyForBezierRight = false;
    }
    */
}
