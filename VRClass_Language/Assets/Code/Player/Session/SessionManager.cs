using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SessionManager : SingletonComponent<SessionManager> {

    public int userID;
	public GoogleAnalyticsV4 analytics;
	private UserList userList;
	private UserProfile user;

	private void Awake() {
		userList = new UserList();
		initAnalytics ();
		createNewUser ();
	}
    
	// Use this for initialization
	private void Start () {
	}

	private void initAnalytics() {
		analytics = GameObject.Find ("GAv4").GetComponent<GoogleAnalyticsV4> ();
		loadUserList ();
	}

	private void loadUserList() {
		userList = new UserList();
		userList.users = new List<UserProfile> ();
		BinaryFormatter bf = new BinaryFormatter();
		if (File.Exists (Application.persistentDataPath + "USERLIST")) {
			FileStream file = File.Open(Application.persistentDataPath + "USERLIST", FileMode.Open);
			userList.users = (List<UserProfile>)bf.Deserialize(file);
			file.Close();
			Debugger.printLog ("Lista de usuarios cargada! Nº usuarios: " + userList.users.Count);
		}
		else {
			Debugger.printLog("Lista de usuarios no existe. Creando lista de usuarios!");
			FileStream file = File.Create(Application.persistentDataPath + "USERLIST");
			bf.Serialize(file, userList.users);
			file.Close();
		}
	}

	public void createNewUser()
    {
        BinaryFormatter bf = new BinaryFormatter();
        UserGameData userData = new UserGameData();
        UserProfile userProfile = new UserProfile();
		loadUserList ();
		userProfile.userID = userList.users.Count;
		Debugger.printLog ("NEW USER: " + userProfile.userID);
		FileStream file = File.Create (Application.persistentDataPath + "USER_" + userProfile.userID.ToString ().PadLeft (3, '0'));
		userProfile.user = userData;
		userList.users.Add (userProfile);
		userID = userProfile.userID;
        bf.Serialize(file, userProfile);
        file.Close();
		FileStream fileList = File.Open(Application.persistentDataPath + "USERLIST", FileMode.Open);
		bf.Serialize(fileList, userList.users);
		fileList.Close ();
		loadUserProfileAndData (userID);
        userData = null;
        userProfile = null;
    }

	public bool loadUserProfileAndData(int ID)
    {
		if (checkUserProfileData(ID))
        {
            BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "USER_" + ID.ToString ().PadLeft (3, '0'), FileMode.Open);
            UserProfile userData = (UserProfile)bf.Deserialize(file);
            file.Close();
			user = userData;
			userID = userData.userID;
            loadUserGameData();
			return true;
        }
        else
        {
			return false;
        }
    }

    private bool checkUserProfileData(int ID) // check user ID
    {
		loadUserList ();
		return (userList.users.Exists (x => x.userID == ID)) ? true : false;
    }

    private void loadUserGameData()
    {
		analytics.enableAdId = true;
		analytics.StartSession ();
		analytics.SetOnTracker (Fields.USER_ID,userID.ToString().PadLeft(3,'0'));
		analytics.LogEvent (new EventHitBuilder().SetEventCategory("User Session").SetEventAction("User sign in"));
		analytics.DispatchHits ();
		/* cargar los datos del usuario*/
    }

	public static void sendEvent (string category, string action, string label ="empty", int value = 0) {
		instance.analytics.LogEvent (category, action, label, value);
	}

    private void saveUserGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
		if (File.Exists(Application.persistentDataPath + "USER_" + userID.ToString().PadLeft(3,'0')))
        {
			FileStream file = File.Open (Application.persistentDataPath + "USER_" + userID.ToString ().PadLeft (3, '0'), FileMode.Open);
			UserProfile USER = (UserProfile)bf.Deserialize(file);
			// realizar cambios en userData
			bf.Serialize(file, USER);
            file.Close();
        }
    }
}

// system.Serializable
[System.Serializable]
public class UserProfile
{
	public int userID;
	public UserGameData user;
}

[System.Serializable]
 public class UserGameData
{
	public bool completedLevel1 = false;
	public bool completedLevel2 = false;
	public bool completedLevel3 = false;
	List<AchievementKeysList> achievementList = new List<AchievementKeysList>();
}

[System.Serializable]
 public class UserList
{
	public List<UserProfile> users;

	public UserList () {
		users = new List<UserProfile> ();
	}
}
