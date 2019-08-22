using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class NavigationScript : MonoBehaviour
{
    private PlayVideo videoScript;
    
    [SerializeField]
    private List<Button> modButtons;
    [SerializeField]
    private Image contentImage;
    [SerializeField]
    private List<Sprite> contentImages;

    // Start is called before the first frame update
    void Start()
    {
        videoScript = FindObjectOfType<PlayVideo>();
        OpenModule(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
            if(EditorApplication.isPlaying == true) UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    private void Awake()
    {
    }

    public void OpenModule(int module)
    {
        if(contentImage.gameObject.activeSelf)
        {
            contentImage.gameObject.SetActive(false);
        }
        contentImage.sprite = contentImages[module];
        videoScript.playModule(module);
    }

    public void ModuleComplete(int module)
    {
        Text text = modButtons[module].GetComponentInChildren<Text>();
        text.text = "Module Complete!";
        text.color = Color.green;
        text.fontSize = 14;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
