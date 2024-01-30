using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.Networking;
public class Register : MonoBehaviour

{



    public InputField nameField;
    public InputField ageField;
    public InputField heightFeild;
    public InputField weightField;
    public InputField emailFeild;
    public InputField passwordField;
    public InputField confirmField;

    public Toggle MaleToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Validate(){
        if (nameField.text == "") {
            GameManager.instance.showToastOnUiThread("Name can not empty");
            return false;
        }
                if (weightField.text == "") {
            GameManager.instance.showToastOnUiThread("Weight can not empty");
            return false;
        }
                if (heightFeild.text == "") {
            GameManager.instance.showToastOnUiThread("Height can not empty");
            return false;
        }
                if (ageField.text == "") {
            GameManager.instance.showToastOnUiThread("Age can not empty");
            return false;
        }
        if (emailFeild.text == "") {
            GameManager.instance.showToastOnUiThread("Email can not empty");
            return false;
        }
        if (passwordField.text == "" || confirmField.text == "")  {
            GameManager.instance.showToastOnUiThread("password can not empty");
            return false;
        }
        if (passwordField.text != confirmField.text)  {
            GameManager.instance.showToastOnUiThread("passwords do not match");
            return false;
        }

        return true;
    }

    public void OnRegister(){
        if (Validate() == false) {
            return;
        }

        GameManager.instance.user = new RegisterData(){
            name = nameField.text,
            email = emailFeild.text.ToLower(),
            password = passwordField.text,

            age =  Int64.Parse(ageField.text),
            height =  Int64.Parse(heightFeild.text),
            weight =  Int64.Parse(weightField.text),
            
        }; 

        if (MaleToggle.isOn) {
               GameManager.instance.user.gender = "Male";
        }else{
               GameManager.instance.user.gender = "Female";
        }
        Debug.Log( JsonUtility.ToJson(   GameManager.instance.user));

            GameManager.instance.fetching.SetActive(true);


        StartCoroutine(Post("https://api.enthu.games/register",JsonUtility.ToJson(   GameManager.instance.user) ));


    }

    IEnumerator Post(string url, string bodyJsonString)
    {

        UnityWebRequest www = UnityWebRequest.Put(url, bodyJsonString);
yield return www.SendWebRequest();

            GameManager.instance.fetching.SetActive(false);


  if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log(www.result.ToString());
                    GameManager.instance.showToastOnUiThread( "soem error occurred. " + www.result.ToString());

                
            }
            else
            {
                Debug.Log("Form upload complete!");
                GameManager.instance.showToastOnUiThread( "registered successfully. Please login!");
                SceneManager.LoadScene("Login");
            }
    }

    public void OnBack(){
        SceneManager.LoadScene("Login");
    }

        public void OnClear(){
        SceneManager.LoadScene("Register");
        
    }
}
