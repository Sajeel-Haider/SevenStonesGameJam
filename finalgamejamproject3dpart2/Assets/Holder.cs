using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    public bool CheckCubes()
    {
        bool isCubesPresent = false;
        Collider[] colliders = Physics.OverlapBox(transform.position + new Vector3(0, 3, 0), new Vector3(10, 7, 1.5f));
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Cube")
            {
                isCubesPresent = true;

            }
        }
        return isCubesPresent;
    }
    private void OneDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 3, 0), new Vector3(10, 7, 1.5f));

    }
}
