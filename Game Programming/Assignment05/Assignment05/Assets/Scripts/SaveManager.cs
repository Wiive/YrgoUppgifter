using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
        LoadData();
        LoadNames();
    }

    public void SaveData()
    {
        Debug.Log("Saved");

        PlayerPrefs.SetFloat("p1-pos-x", playerOne.transform.position.x);
        PlayerPrefs.SetFloat("p1-pos-y", playerOne.transform.position.y);
        PlayerPrefs.SetFloat("p1-rot-z", playerOne.transform.eulerAngles.z);

        PlayerPrefs.SetFloat("p2-pos-x", playerTwo.transform.position.x);
        PlayerPrefs.SetFloat("p2-pos-y", playerTwo.transform.position.y);
        PlayerPrefs.SetFloat("p2-rot-z", playerTwo.transform.eulerAngles.z);
    }


    public void LoadData()
    {
        Debug.Log("Loading");

        Vector3 pos = Vector3.zero;
        Vector3 rot = Vector3.zero;

        pos.x = PlayerPrefs.GetFloat("p1-pos-x");
        pos.y = PlayerPrefs.GetFloat("p1-pos-y");
        rot.z = PlayerPrefs.GetFloat("p1-rot-z");

        playerOne.transform.position = pos;
        playerOne.transform.eulerAngles = new Vector3(0,0, rot.z);

        pos.x = PlayerPrefs.GetFloat("p2-pos-x");
        pos.y = PlayerPrefs.GetFloat("p2-pos-y");
        rot.z = PlayerPrefs.GetFloat("p2-rot-z");

        playerTwo.transform.position = pos;
        playerTwo.transform.eulerAngles = new Vector3(0, 0, rot.z);
    }

    public void LoadNames()
    {
        var nameTagManager = GetComponent<NameTagManager>();

        for (int i = 0; i < nameTagManager.nameTags.Length; i++)
        {
            nameTagManager.nameTags[i].GetComponent<TMP_Text>().text = PlayerPrefs.GetString("p" + (i+1) + "-name");
        }
    }
}
