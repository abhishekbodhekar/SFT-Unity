using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using  SimpleJSON;
using System;



public class Login : MonoBehaviour
{

    public InputField emailInputField;
    public InputField passwordInputField;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoginBtnClick(){

            if(emailInputField.text == "" || passwordInputField.text == ""){
                GameManager.instance.showToastOnUiThread("email or password can not be empty");
                return;
            }

            LoginClass data = new LoginClass (){
                email =   emailInputField.text.ToLower(),
                password = passwordInputField.text
            };

            GameManager.instance.fetching.SetActive(true);

            StartCoroutine(LoginStart("https://api.enthu.games/login", JsonUtility.ToJson(data)));


    }

        IEnumerator LoginStart(string url, string bodyJsonString)
    {

        UnityWebRequest www = UnityWebRequest.Put(url, bodyJsonString);
yield return www.SendWebRequest();
            GameManager.instance.fetching.SetActive(false);


  if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                Debug.Log(www.result.ToString());
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);

                GameManager.instance.loginResponse =  JsonUtility.FromJson<LoginResponse>(jsonResult);
                if (GameManager.instance.loginResponse.result == true ){
                GameManager.instance.user = GameManager.instance.loginResponse.message;

                }else{
                    GameManager.instance.showToastOnUiThread(GameManager.instance.loginResponse.error);
                }
            }
            else
            {
                Debug.Log("Login complete!");
                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(jsonResult);


                GameManager.instance.loginResponse = new LoginResponse(){
                    message = new RegisterData()
                };

                var resp =  JSON.Parse(jsonResult).AsObject;
                GameManager.instance.loginResponse.error = resp["error"].Value.ToString();
                GameManager.instance.loginResponse.result = resp["result"].AsBool;
               var resp2 = JSON.Parse(resp["message"].ToString());


                if (GameManager.instance.loginResponse.result == true ){
                GameManager.instance.user =  new RegisterData(){
                    height = resp2["height"].AsLong,
                    weight = resp2["weight"].AsLong,
                    email = resp2["email"].Value,
                    gender = resp2["gender"].Value,
                    name = resp2["name"].Value,
                    password = resp2["password"].Value,
                    age = resp2["age"].AsLong,
      
                };


                    SceneManager.LoadScene("Main");


                }else{
                    GameManager.instance.showToastOnUiThread(GameManager.instance.loginResponse.error);
                }

            }
    }

    public void OnCloseAppBtnClick(){
        Application.Quit();

    }

    public void OnRegisterBtnClick(){
        SceneManager.LoadScene("Register");
    }



    
}
