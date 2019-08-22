using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeyToContinue : MonoBehaviour
{

    [SerializeField]
    private string nextScene = "Main";

    private void Awake()
    {
    }

    void Update()
    {
        if(!Input.GetKey(KeyCode.Escape) && Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
