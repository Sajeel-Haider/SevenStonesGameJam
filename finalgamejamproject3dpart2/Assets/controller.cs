using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{

    int flag = 0;
    private Vector3 addposition = new Vector3();
    public GameObject child;
    public GameObject child1;
    private Rigidbody RB2;
    public GameObject scorecount;
    public GameObject Playerid;
    public GameObject scoreview;
    public GameObject itself;
    public Vector3 powerbarposition = new Vector3();
    private int count = 0;
    private int[] score = { 0, 0 };
    private int indexscore = 0;
    private bool showpopup = false;
    private Vector3 orignalpos = new Vector3();
    public float timeRemaining = 0.1f;
    Rigidbody rb;
    private bool ishit = false;
    private bool barcontrol = false;
    float speed = 40;
    public GameObject Stoneposition2;
    public GameObject Stoneposition3;
    public GameObject Stoneposition4;
    public GameObject Stoneposition5;
    public GameObject Stoneposition6;
    public GameObject Stoneposition7;
    // Start is called before the first frame update
    void Start()
    {

        addposition.x = 0;
        addposition.y = 0.1f;
        addposition.z = 0;
        powerbarposition = child1.GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
        orignalpos = transform.position;
        // child = transform.Find("slider");
        // child1 = transform.Find("powerbar");

        //child2 = transform.Find("Canvas").transform.Find("scorecount");



        //Debug.Log(Input.GetButtonDown("Fire1"));


    }
    void OnGUI()
    {
        if (showpopup)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
               , 300, 250), ShowGUI, "Invalid word");

        }
    }

    void ShowGUI(int windowID)
    {
        // You may put a label to show a message to the player

        GUI.Label(new Rect(65, 40, 200, 30), "SWTCHING TO PLAYER 2");

        // You may put a button to close the pop up too



    }
    void Repeatingpowerbar()
    {
        // Debug.Log(child.transform.position .y);
        //Debug.Log(powerbarposition=.y);
        //Debug.Log(flag);
        if (flag == 0)
        {
            if (child.transform.position.y > (powerbarposition.y + 1.9f))
            {
                flag = 1;
                // Debug.Log(child.transform.position.y);
            }
            else
            {
                flag = 2;
                //Debug.Log(child.transform.position.y);
            }
        }
        else if (flag == 1)
        {
            if (child.transform.position.y < (powerbarposition.y - 1.9f))
            {
                flag = 0;
                //Debug.Log(child.transform.position.y);
            }

            child.transform.position -= addposition;
        }
        else if (flag == 2)
        {
            child.transform.position += addposition;
            if (child.transform.position.y > (powerbarposition.y + 1.9f))
            {
                flag = 0;
                //Debug.Log(child.transform.position.y);
            }
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Cube" || collision.gameObject.name == "Cube1" || collision.gameObject.name == "Cube3" || collision.gameObject.name == "Cube4" || collision.gameObject.name == "Cube5")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log(collision.gameObject.name);
            //rb.isKinematic = true;
            // rb.useGravity = true;
            ishit = true;

        }
    }
    // Update is called once per frame
    void Update()
    {

        if (count == 3)
        {
            indexscore = 1;
            Playerid.GetComponent<UnityEngine.UI.Text>().text = "Player 2";
            scoreview.GetComponent<UnityEngine.UI.Text>().text = $"Score for player{indexscore + 1 }";
            showpopup = true;
            //Debug.Log(Playerid);
        }
        else
        {
            showpopup = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if ((child.transform.position.y <= (powerbarposition.y + 1f) && child.transform.position.y > (powerbarposition.y + 0.75f)) || (child.transform.position.y >= (powerbarposition.y - 1f) && child.transform.position.y < (powerbarposition.y - 0.75f)))
            {
                scorecount.GetComponent<UnityEngine.UI.Text>().text = $" {score[indexscore] += 2}";
                Vector3 _mousePosition = Stoneposition2.GetComponent<Transform>().position;
                Vector3 _difference = (_mousePosition - transform.position).normalized;
                RB2 = Stoneposition2.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition3.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition4.GetComponent<Rigidbody>();
                RB2.isKinematic = false; rb.isKinematic = false;
                RB2 = Stoneposition5.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition6.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                rb.velocity = new Vector3(0, _difference.y * speed, _difference.z * speed);
                //for (int i = 0; i < 10000000; i++) ;
                //rb.velocity = Vector3.zero;
                //transform.position = orignalpos;
                // GameManager.Instance.StartCoroutine(GameManager.Instance.ThrowBall(gameObject));
            }
            else if ((child.transform.position.y <= (powerbarposition.y + 0.75f) && child.transform.position.y > (powerbarposition.y + 0.5f)) || (child.transform.position.y >= (powerbarposition.y - 0.75f) && child.transform.position.y < (powerbarposition.y - 0.5f)))
            {
                scorecount.GetComponent<UnityEngine.UI.Text>().text = $" {score[indexscore] += 3}";
                Vector3 _mousePosition = Stoneposition3.GetComponent<Transform>().position;
                Vector3 _difference = (_mousePosition - transform.position).normalized;
                rb.isKinematic = false;
                RB2 = Stoneposition3.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition4.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition5.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition6.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                rb.velocity = new Vector3(0, _difference.y * speed, _difference.z * speed);


            }
            else if (child.transform.position.y <= (powerbarposition.y + 0.5f) || child.transform.position.y > (powerbarposition.y - 0.5f))
            {
                scorecount.GetComponent<UnityEngine.UI.Text>().text = $" {score[indexscore] += 4}";
                Vector3 _mousePosition = Stoneposition4.GetComponent<Transform>().position;
                Vector3 _difference = (_mousePosition - transform.position).normalized;
                rb.isKinematic = false;
                RB2 = Stoneposition4.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition5.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition6.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                rb.velocity = new Vector3(0, _difference.y * speed, _difference.z * speed);

            }
            else if ((child.transform.position.y <= (powerbarposition.y + 0.25f) && child.transform.position.y > powerbarposition.y) || (child.transform.position.y >= (powerbarposition.y - 0.25f) && child.transform.position.y < powerbarposition.y))
            {
                scorecount.GetComponent<UnityEngine.UI.Text>().text = $" {score[indexscore] += 5}";
                Vector3 _mousePosition = Stoneposition5.GetComponent<Transform>().position;
                Vector3 _difference = (_mousePosition - transform.position).normalized;
                rb.isKinematic = false;
                RB2 = Stoneposition5.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                RB2 = Stoneposition6.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                rb.velocity = new Vector3(0, _difference.y * speed, _difference.z * speed);

                //GameManager.Instance.StartCoroutine(GameManager.Instance.ThrowBall(gameObject));
            }
            else if (child.transform.position.y == powerbarposition.y)
            {
                scorecount.GetComponent<UnityEngine.UI.Text>().text = $" {score[indexscore] += 7}";
                Vector3 _mousePosition = Stoneposition6.GetComponent<Transform>().position;
                Vector3 _difference = (_mousePosition - transform.position).normalized;
                rb.isKinematic = false;
                RB2 = Stoneposition6.GetComponent<Rigidbody>();
                RB2.isKinematic = false;
                rb.velocity = new Vector3(0, _difference.y * speed, _difference.z * speed);


            }

            count++;
            barcontrol = true;
        }
        else if (!barcontrol)
        {
            for (int i = 0; i < 100000000; i++) ;
            Repeatingpowerbar();
            //rb.velocity = Vector3.zero;
            //transform.position = orignalpos;
        }
        if (ishit)
        {
            rb.useGravity = true;

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               
                Debug.Log("Time has run out!");
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
                ishit = false;
                transform.position = orignalpos;
                timeRemaining = 0.1f;
            }
            SceneManager.LoadScene("stack", LoadSceneMode.Single);
        }



    }
}

