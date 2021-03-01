using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUserData : MonoBehaviour
{
  public void LoadUserDataButton()
    {
        ActiveUser.Instance.LoadUserData();
    }
}
