

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    string toastString;

    public static GameManager instance = null; 


    public   RegisterData user;
    public   User userEnteredInfo;
    public   LoginResponse loginResponse;

    public GameObject fetching;

     void Awake (){

        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(instance);

        }

        instance.userEnteredInfo = new User();
        instance.user = new RegisterData();

    }


AndroidJavaObject currentActivity;

    public void showToastOnUiThread(string toastString){
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            this.toastString = toastString;
            
            currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
}
 
void showToast(){
Debug.Log ("Running on UI thread");
AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
AndroidJavaObject javaString=new AndroidJavaObject("java.lang.String",toastString);
AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
toast.Call ("show");
}
}