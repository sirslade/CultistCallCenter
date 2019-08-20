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
    private List<Image> contentImages;
    [SerializeField]
    private List<GameObject> contentSections;
    [SerializeField]
    private NavigationScript navScript;


    public void CorrectAnswer()
    {
        FinishSection();
    }

    public void IncorrectAnswer()
    {
        // Some sort of try again thing
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
