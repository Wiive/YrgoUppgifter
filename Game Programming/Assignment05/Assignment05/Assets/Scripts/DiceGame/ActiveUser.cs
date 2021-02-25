using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUser : MonoBehaviour
{
    private static ActiveUser instance;
    public static ActiveUser Instance { get { return instance; } }

    public UserInfo userInfo;
    public string userID;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void LoadUserData()
    {
        userID = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        StartCoroutine(FirebaseManager.Instance.LoadData("users/" + userID, LoadUser));
    }

    public void LoadUser(string jsonData)
    {
        if (jsonData == null || jsonData == "")
        {
            userInfo = new UserInfo();
            SaveUser();
        }
        else
        {
            userInfo = JsonUtility.FromJson<UserInfo>(jsonData);
        }

        //GetComponent<LevelManager>().LoadScene(1);
    }

    public void SaveUser()
    {
        string jsonData = JsonUtility.ToJson(userInfo);
        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, jsonData));
    }
}
