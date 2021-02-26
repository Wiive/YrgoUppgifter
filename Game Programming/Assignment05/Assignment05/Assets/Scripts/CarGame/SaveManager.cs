using System;
using System.IO;
using System.Net;
using System.Text;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;

[Serializable]
public class OurPlayers
{
   public PlayerInfo[] players;
}

[Serializable]
public class PlayerInfo
{
    public string Name;
    public Vector3 Position;
}

public class SaveManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
        //SaveData();
        //LoadData();
    }

    public void SaveData()
    {
        Debug.Log("Saved");

        //Get player info
        var players = FindObjectsOfType<PlayerMovement>();

        //Create holder object
        var ourPlayers = new OurPlayers();

        ourPlayers.players = new PlayerInfo[players.Length];

        //Put info in playerinfo class
        for (int i = 0; i < players.Length; i++)
        {
            ourPlayers.players[i] = new PlayerInfo();
            ourPlayers.players[i].Position = players[i].transform.position;
            ourPlayers.players[i].Name = players[i].name;
        }

        //turn class into json
        string jsonsString = JsonUtility.ToJson(ourPlayers);

        //save that
        //PlayerPrefs.SetString("json", jsonsString);
        //SaveToFile("SiblingWasGame", jsonsString);
        //SaveOnline("SiblingWasGame", jsonsString);
        SaveToFireBase(jsonsString);

        //Save players rotations
        PlayerPrefs.SetFloat("p1-rot-z", playerOne.transform.eulerAngles.z);
        PlayerPrefs.SetFloat("p2-rot-z", playerTwo.transform.eulerAngles.z);
    }

    private void SaveToFireBase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var dataTask = db.RootReference.Child("users/").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).SetRawJsonValueAsync(data);
    }

    public void LoadData()
    {
        Debug.Log("Loading");

        //string jsonString = PlayerPrefs.GetString("json");

        //Load from file
        string jsonString2 = Load("SiblingWasGame");

        //Load from server
        //string jsonString = LoadOnline("SiblingWasGame");

        LoadFromFirebase();

    }


    private void LoadFromFirebase()
    {
        var db = FirebaseDatabase.DefaultInstance;
        var dataTask = db.RootReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).GetValueAsync().ContinueWithOnMainThread(task =>
        { 
            if (task.Exception != null)
            {
                Debug.LogError(task.Exception);
            }
            DataSnapshot snap = task.Result;

           LoadState(snap.GetRawJsonValue());
        });
    }


    private void LoadState(string jsonString)
    {
        var ourPlayers = JsonUtility.FromJson<OurPlayers>(jsonString);

        var players = FindObjectsOfType<PlayerMovement>();

        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.position = ourPlayers.players[i].Position;
            players[i].name = ourPlayers.players[i].Name;
        }

        //Load Names
        var nameTagManager = GetComponent<NameTagManager>();

        for (int i = 0; i < nameTagManager.nameTags.Length; i++)
        {
            nameTagManager.nameTags[i].GetComponent<TMP_Text>().text = ourPlayers.players[i].Name;
        }

        //Loading players rotation
        Vector3 rot = Vector3.zero;

        rot.z = PlayerPrefs.GetFloat("p1-rot-z");
        playerOne.transform.eulerAngles = new Vector3(0, 0, rot.z);

        rot.z = PlayerPrefs.GetFloat("p2-rot-z");
        playerTwo.transform.eulerAngles = new Vector3(0, 0, rot.z);
    }

    public void SaveToFile(string fileName, string jsonString)
    {
        // Open a file in write mode. This will create the file if it's missing.
        // It is assumed that the path already exists.
        using (var stream = File.OpenWrite(Application.persistentDataPath + "\\" + fileName))
        {
            // Truncate the file if it exists (we want to overwrite the file)
            stream.SetLength(0);

            // Convert the string into bytes. Assume that the character-encoding is UTF8.
            // Do you not know what encoding you have? Then you have UTF-8
            var bytes = Encoding.UTF8.GetBytes(jsonString);

            // Write the bytes to the hard-drive
            stream.Write(bytes, 0, bytes.Length);

            // The "using" statement will automatically close the stream after we leave
            // the scope - this is VERY important
        }
    }

    public string Load(string fileName)
    {
        // Open a stream for the supplied file name as a text file
        using (var stream = File.OpenText(Application.persistentDataPath + "\\" + fileName))
        {
            // Read the entire file and return the result. This assumes that we've written the
            // file in UTF-8
            return stream.ReadToEnd();
        }
    }

    public string LoadOnline(string name)
    {
        var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/" + name);
        var response = (HttpWebResponse)request.GetResponse();

        // Open a stream to the server so we can read the response data it sent back from our GET request
        using (var stream = response.GetResponseStream())
        {
            using (var reader = new StreamReader(stream))
            {
                // Read the entire body as a string
                var body = reader.ReadToEnd();

                return body;
            }
        }
    }

    //Saves the playerInfo string on the server.
    public void SaveOnline(string fileName, string saveData)
    {
        //url
        var request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/" + fileName);
        request.ContentType = "application/json";
        request.Method = "PUT";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(saveData);
        }

        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Debug.Log(result);
        }
    }
}
