using Firebase.Database;
using System.Collections;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager Instance { get; private set; }

    public delegate void OnLoadedDelegate(string jsonData);
    public delegate void OnSaveDelegate();

    FirebaseDatabase db;

    private void Awake()
    {
        //Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }           
        else
        {
            Instance = this;
        }         

        db = FirebaseDatabase.DefaultInstance;
    }

    public IEnumerator LoadData(string path, OnLoadedDelegate onLoadedDelegate)
    {
        var dataTask = db.RootReference.Child(path).GetValueAsync();
        yield return new WaitUntil(() => dataTask.IsCompleted);

        if (dataTask.Exception != null)
        {
            Debug.LogWarning(dataTask.Exception);
        }         

        string jsonData = dataTask.Result.GetRawJsonValue();

        onLoadedDelegate(jsonData);
    }


    public IEnumerator LoadDataMultiple(string path, OnLoadedDelegate onLoadedDelegate)
    {
        var dataTask = db.RootReference.Child(path).GetValueAsync();
        yield return new WaitUntil(() => dataTask.IsCompleted);
        string jsonData = dataTask.Result.GetRawJsonValue();

        if (dataTask.Exception != null)
        {
            Debug.LogWarning(dataTask.Exception);
        }           

        foreach (var item in dataTask.Result.Children)
        {
            onLoadedDelegate(item.GetRawJsonValue());
        }
    }

    public IEnumerator SaveData(string path, string data, OnSaveDelegate onSaveDelegate = null)
    {
        var dataTask = db.RootReference.Child(path).SetRawJsonValueAsync(data);
        yield return new WaitUntil(() => dataTask.IsCompleted);

        if (dataTask.Exception != null)
        {
            Debug.LogWarning(dataTask.Exception);
        }
         
        if (onSaveDelegate != null)
        {
            onSaveDelegate();
        }
    }
}
