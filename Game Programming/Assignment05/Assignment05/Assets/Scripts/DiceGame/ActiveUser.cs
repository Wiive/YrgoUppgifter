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
        Debug.Log("Starting to try to LoadUser");
        if (jsonData == null || jsonData == "")
        {
            Debug.Log("user is empty creating new empty user");
            userInfo = new UserInfo();
            SaveUser();          
        }
        else
        {
            Debug.Log("Trying to load user from Firebase");
            userInfo = JsonUtility.FromJson<UserInfo>(jsonData);
        }
    }

    public void SaveUser()
    {
        string jsonData = JsonUtility.ToJson(userInfo);
        StartCoroutine(FirebaseManager.Instance.SaveData("users/" + userID, jsonData));
    }
}
