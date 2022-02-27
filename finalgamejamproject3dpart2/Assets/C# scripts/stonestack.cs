using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonestack : MonoBehaviour
{
    private float min_X = -7f, max_X = 9f;
    private bool canMove;
    private float move_Speed = 5f;
    private Rigidbody myBody;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.useGravity = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 9) > 0)
        {
            move_Speed *= -1f;
        }
        gameController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;
            if (temp.x > max_X)
            {
                move_Speed *= -1f;
            }
            else if (temp.x < min_X)
            {
                move_Speed *= -1f;
            }
            transform.position = temp;
        }
    }
    public void DropBox()
    {
        canMove = false;
        myBody.useGravity = true;
    }
    void Landed()
    {
        if (gameOver)
        {
            return;
        }
        ignoreCollision = true;
        ignoreTrigger = true;
        gameController.instance.SpawnNewBox();
    }
    void RestartGame()
    {
        gameController.instance.RestartGame();
    }
    void OnCollisionEnter(Collision target)
    {
        if (ignoreCollision)
        {
            return;
        }
        if (target.gameObject.tag == "platform")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
        if (target.gameObject.tag == "stone")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
        }
    }
    void OnTriggerEnter(Collider target)
    {
        
        if (target.gameObject.tag == "GameOver")
        {
            Debug.Log("GameOver");
            CancelInvoke("Landed");
            gameOver = true;
            ignoreCollision = true;
            Invoke("RestartGame", 1f);
        }
       
    }



}
