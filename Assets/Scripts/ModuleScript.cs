using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleScript : MonoBehaviour
{
    // Module script should have generic button events for "Right answer" and "Wrong answer"
    // Modules should change the content image as necessary
    // 

    private int currentSection = 0;

    [SerializeField]
    private int moduleNumber;
    [SerializeField]
    private List<GameObject> contentSections;
    [SerializeField]
    private NavigationScript navScript;

    [SerializeField]
    private List<Sprite> displayImages;
    [SerializeField]
    private Image displayImage;
    


    private void Awake()
    {
        contentSections[0].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void CorrectAnswer()
    {
        FinishSection();
    }

    public void IncorrectAnswer()
    {
        // Some sort of show 
    }

    void FinishSection()
    {
        contentSections[currentSection].SetActive(false);
        currentSection++;
        if(currentSection > contentSections.Count)
        {
            navScript.ModuleComplete(moduleNumber);
        } else {
        contentSections[currentSection].SetActive(true);
        }
    }
}
