using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class FirebaseTest : MonoBehaviour
{
	[Header("Sign In")]
	public TMP_InputField emailTextBox;
	public TMP_InputField passwordTextBox;
	public TMP_Text accountLoginWarning;

	[Header("Sign Up")]
	public CanvasGroup signUpCanvas;
	public TMP_InputField newEmail;
	public TMP_InputField newPassword;
	public TMP_InputField confirmPassword;
	public TMP_InputField newName;

	private LevelManager levelManager;

	void Start()
	{
		FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
		{
			if (task.Exception != null)
			{
				Debug.LogError(task.Exception);
			}

		});
		accountLoginWarning.text = "";
		levelManager = GetComponent<LevelManager>();
		signUpCanvas.alpha = 0;
		signUpCanvas.blocksRaycasts = false;
	}


	public void TryToAddUser()
	{
		var email = newEmail.text;
		var password = newPassword.text;
		var checkPassword = confirmPassword.text;
		var name = newName.text;
		if (password != checkPassword)
		{
			accountLoginWarning.text = "Passwords are not the same";
		}
		else if (name == "" || name == null)
		{
			accountLoginWarning.text = "Enter a name";
		}
		else
		{
			StartCoroutine(RegUser(email, password, name));
			HideSignUpCanvas();
		}			
	}

	private IEnumerator RegUser(string email, string password, string name)
	{
		Debug.Log("Starting Registration");
		var auth = FirebaseAuth.DefaultInstance;
		var regTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
		yield return new WaitUntil(() => regTask.IsCompleted);

		if (regTask.Exception != null)
		{
			Debug.LogWarning(regTask.Exception);
		}
		else
		{
			Debug.Log("Registration Complete");
			var userInfo = new UserInfo();
			userInfo.name = name;
			string jsondata = JsonUtility.ToJson(userInfo);
			var db = FirebaseDatabase.DefaultInstance;
			var dataTask = db.RootReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).SetRawJsonValueAsync(jsondata);
		}
	}


	public void ShowSignUpCanvas()
	{
		signUpCanvas.alpha = 1;
		signUpCanvas.blocksRaycasts = true;
	}

	public void HideSignUpCanvas()
	{
		signUpCanvas.alpha = 0;
		signUpCanvas.blocksRaycasts = false;
	}


	public void TryToSignIn()
	{
		var email = emailTextBox.text;
		var password = passwordTextBox.text;
		StartCoroutine(SignIn(email, password));
	}


	private IEnumerator SignIn(string email, string password)
	{
		Debug.Log("Atempting to log in");
		var auth = FirebaseAuth.DefaultInstance;
		var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);
		yield return new WaitUntil(() => loginTask.IsCompleted);

		if (loginTask.Exception != null)
		{
			accountLoginWarning.text = "That account does not exist";
			Debug.LogWarning(loginTask.Exception);
		}
		else
		{
			accountLoginWarning.text = "";
			Debug.Log("login completed");
			levelManager.LoadScene("DiceLobby");
			ActiveUser.Instance.LoadUserData();
		}

		//StartCoroutine(DataTest(FirebaseAuth.DefaultInstance.CurrentUser.UserId, "TestWrite"));
	}

	private IEnumerator DataTest(string userID, string data)
	{
		Debug.Log("Trying to write data");
		var db = FirebaseDatabase.DefaultInstance;
		var dataTask = db.RootReference.Child("users").Child(userID).SetValueAsync(data);

		yield return new WaitUntil(() => dataTask.IsCompleted);

		if (dataTask.Exception != null)
			Debug.LogWarning(dataTask.Exception);
		else
			Debug.Log("DataTestWrite: Complete");
	}
}