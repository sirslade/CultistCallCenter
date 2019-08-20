using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour
{
    private PlayVideo videoScript;

    // Start is called before the first frame update
    void Start()
    {
        videoScript = FindObjectOfType<PlayVideo>();
        OpenModule(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
    }

    public void OpenModule(int module)
    {
        videoScript.playModule(module);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
