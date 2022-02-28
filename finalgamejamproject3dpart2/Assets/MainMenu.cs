using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void playgame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    private void Update()
    {
        Input.GetButton("start");
    }
    void onClick()
    {
        if(Input.GetButton("start"))
            playgame();
    }
}
