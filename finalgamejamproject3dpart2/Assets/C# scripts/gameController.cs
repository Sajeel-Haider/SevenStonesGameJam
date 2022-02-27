using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gameController : MonoBehaviour
{
    public static gameController instance;
    public stonespawner stone_Spawner;
    [HideInInspector]
    public stonestack currentBox;
    private int moveCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        stone_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }
    public void SpawnNewBox()
    {
        Invoke("NewBox", 2f);
    }
    void NewBox()
    {
        stone_Spawner.SpawnBox();
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }

}
