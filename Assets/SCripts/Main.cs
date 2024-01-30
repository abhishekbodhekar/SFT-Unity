using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    public Color red;
    public Color yellow;
    public Color green;

    public TextMeshProUGUI BMItext;
    public TextMeshProUGUI HelloText;
    public Image underwightImage;
    public Image NormalwightImage;
    public Image overwightImage;
    public Image ObeseImage;
    public Slider CalorySlider;
    public TextMeshProUGUI CaloryText;
    public Dropdown AllergyDropdown;
    public Dropdown EatingHabitDropdown;
    public Dropdown MedicalConditionDropdown;

    void Start()
    {

        Debug.Log(Convert.ToSingle(GameManager.instance.user.height));
        Debug.Log(Convert.ToSingle(GameManager.instance.user.height)/100);







        GameManager.instance.userEnteredInfo = new User{
    myBMI =  Convert.ToSingle(GameManager.instance.user.weight)/ ((Convert.ToSingle(GameManager.instance.user.height) / 100) *  (Convert.ToSingle(GameManager.instance.user.height) / 100))
        };
      // GameManager.userEnteredInfo.myBMI =  GameManager.user.weight / (GameManager.user.height/100);

      HelloText.text = "Hello, " + GameManager.instance.user.name;
      BMItext.text = "Your Body Mass Index is " +  GameManager.instance.userEnteredInfo.myBMI.ToString();

       if (GameManager.instance.userEnteredInfo.myBMI >= 0 && GameManager.instance.userEnteredInfo.myBMI <= 18.5 ) {
                underwightImage.color = red;
                underwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = red;
       }else if (GameManager.instance.userEnteredInfo.myBMI > 18.5 && GameManager.instance.userEnteredInfo.myBMI <= 25 ) {
                underwightImage.color = green;
                underwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = green;

                NormalwightImage.color = green;
                NormalwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = green;



       }else if (GameManager.instance.userEnteredInfo.myBMI > 25 && GameManager.instance.userEnteredInfo.myBMI <= 30 ) {
                underwightImage.color = yellow;
                underwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = yellow;

                NormalwightImage.color = yellow;
                NormalwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = yellow;

                overwightImage.color = yellow;
                overwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = yellow;


       }else if (GameManager.instance.userEnteredInfo.myBMI > 30 ) {
                underwightImage.color = red;
                underwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = red;


                NormalwightImage.color = red;
                NormalwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = red;
                
                overwightImage.color = red;
                overwightImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = red;

                ObeseImage.color = red;
                ObeseImage.gameObject.transform.parent.gameObject.GetComponent<Image>().color = red;

       }
        
    }

    public void OnCaloryChange(){

        GameManager.instance.userEnteredInfo.dailyExercise = CalorySlider.value;

        if (CalorySlider.value == 0 ) {
            CaloryText.text = "I burn 0 to 500 calories everyday";

        }else if (CalorySlider.value == 1 ) {
            CaloryText.text = "I burn 500 to 1500 calories everyday";

        }
        else if (CalorySlider.value == 2 ) {
            CaloryText.text = "I burn 1500 to 2500 calories everyday";
            
        }
        else if (CalorySlider.value == 3 ) {
            CaloryText.text = "I burn 2500 to 3500 calories everyday";
            
        }
        else if (CalorySlider.value == 4 ) {
            CaloryText.text = "I burn more than 3500 calories everyday";
            
        }


    }

    public void OnAllergyChange(){
        GameManager.instance.userEnteredInfo.allergies =  AllergyDropdown.value.ToString();
    }

    public void OnEatingHabitsChange(){
        GameManager.instance.userEnteredInfo.EatingHabitDropdown =  EatingHabitDropdown.value.ToString();

    }

    public void OnMedicalChange(){
        GameManager.instance.userEnteredInfo.medicalConsition =  MedicalConditionDropdown.value.ToString();

    }

    public void Onnutrients(){
        SceneManager.LoadScene("nutrients");
    }

        public void Onfood(){
        SceneManager.LoadScene("food");
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
