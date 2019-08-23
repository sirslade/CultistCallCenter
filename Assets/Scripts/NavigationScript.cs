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
    [SerializeField]
    private List<GameObject> modules;

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
        }
    }

    private void Awake()
    {
    }

    public void OpenModule(int module)
    {
        foreach(GameObject m in modules)
        {
            if(m.activeSelf) m.SetActive(false);
        }
        if(contentImage.gameObject.activeSelf)
        {
            contentImage.gameObject.SetActive(false);
        }
        contentImage.sprite = contentImages[module];
        videoScript.playModule(module);
        foreach(Button b in modButtons)
        {
            if(!b.interactable) b.interactable = true;
        }
        modButtons[module].interactable = false;
    }

    public void ModuleComplete(int module)
    {
        Text text = modButtons[module].GetComponentInChildren<Text>();
        text.text = "Module Complete!";
        text.color = Color.green;
        text.fontSize = 14;
        modButtons[module].interactable = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
