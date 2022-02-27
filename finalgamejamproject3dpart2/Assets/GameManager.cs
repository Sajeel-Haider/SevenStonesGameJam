using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Holder holder;
    public GameObject ballPrefab;
    public Transform ballPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator ThrowBall(GameObject _ball)
    {
        yield return new WaitForSeconds(5);
        
        if (holder.CheckCubes())
        {
           
            ballPrefab.transform.position = ballPosition.position;
            ballPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log(ballPosition.position);
            Debug.Log(ballPrefab.transform.position);
           // GameObject _ballNew = Instantiate(ballPrefab, ballPosition.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Level Complete");
        }
    }
}
