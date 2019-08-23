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
    
    private int orderCountForModule4 = 0;
    [SerializeField]
    private List<Button> buttonListForModule4;

    [SerializeField]
    private List<Slider> slidersForMod3;
    [SerializeField]
    private Text finalText;

    private void Awake()
    {
        contentSections[0].SetActive(true);
        displayImage.sprite = displayImages[0];
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

    public void IncorrectAnswer(Button button)
    {
        button.interactable = false;
        Text text = button.GetComponentInChildren<Text>();
        text.color = Color.red;
        text.text = "X";
    }

    void FinishSection()
    {
        contentSections[currentSection].SetActive(false);
        currentSection++;
        if(currentSection > contentSections.Count - 1)
        {
            navScript.ModuleComplete(moduleNumber);
            gameObject.SetActive(false);
        } else {
            contentSections[currentSection].SetActive(true);
            if(!(currentSection >= displayImages.Count)) {
            displayImage.sprite = displayImages[currentSection];
            }
        }
    }

    public void ClearModule()
    {
        currentSection = 0;
        displayImage.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }


    public void OrderedButton(int order)
    {
        Button button = buttonListForModule4[order];
        if(orderCountForModule4 == order)
        {
            button.interactable = false;
            Text buttonText = button.GetComponentInChildren<Text>();
            buttonText.color = Color.green;
            buttonText.text = buttonText.text + " ✓";
            orderCountForModule4++;
            if(order == 3)
        {
            FinishSection();
        }
        }
        
    }


    public void FillSliderAndContinue(int value)
    {
        //Fuck it, clock's tickin'
        foreach(Slider s in slidersForMod3) {
            s.value = s.value + (float)(value * 0.1); 
            finalText.text = finalText.text + s.value.ToString();
            }
        FinishSection();
    }
}
