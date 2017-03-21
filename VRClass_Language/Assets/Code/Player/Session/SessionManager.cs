using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SessionManager : MonoBehaviour {

    private int usersIDCount;

    [System.Serializable]
    class UserProfile
    {
        public int userID;
        public string userName;
        public string userPassWord;
    }

    [System.Serializable]
    class UserGameData
    {
        public int userID;
        public bool completedLevel1 = false;
        public bool completedLevel2 = false;
        public bool completedLevel3 = false;
        List<AchievementKeysList> achievementList = new List<AchievementKeysList>();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void createNewUser()
    {
        BinaryFormatter bf = new BinaryFormatter();
        UserGameData userData = new UserGameData();
        UserProfile userProfile = new UserProfile();
        if (File.Exists(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA"))
        {
            // usuario ya existe
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA");
            userData.userID = usersIDCount;
            bf.Serialize(file, userProfile);
            bf.Serialize(file, userData);
            file.Close();
        }
        userData = null;
        userProfile = null;
    }

    private void loadUserProfileAndData(string name, string password)
    {
        if (checkUserProfileData(name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + name, FileMode.Open);
            UserProfile userData = (UserProfile)bf.Deserialize(file);
            file.Close();
            if (password.CompareTo(userData.userPassWord) == 0)
            {
                usersIDCount = userData.userID;
                loadUserGameData();
            }
            else
            {
                //EventManager.triggerEvent(Events.EventList.USERV_WRONG_PASS);
            }
        }
        else
        {
            //EventManager.triggerEvent(Events.EventList.USERV_WRONG_USER);
        }
    }

    private bool checkUserProfileData(string name) // check password and user
    {
        return (File.Exists(Application.persistentDataPath + name)) ? true : false;
    }

    private void loadUserGameData()
    {
        if (File.Exists(Application.persistentDataPath + ""))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "", FileMode.Open);
            UserGameData userData = (UserGameData)bf.Deserialize(file);
            file.Close();
            usersIDCount = userData.userID;
        }
    }

    private void saveUserGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        UserGameData userData = new UserGameData();
        if (File.Exists(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA", FileMode.Open);
            bf.Serialize(file, userData);
            file.Close();
        }
        userData = null;
    }

    private void saveUserProfile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        UserProfile userProfile = new UserProfile();
        userProfile.userID = usersIDCount;
        userProfile.userName = "Name";
        userProfile.userPassWord = "PassWord";
        if (File.Exists(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA", FileMode.Open);
            bf.Serialize(file, userProfile);
            file.Close();
        }
        else
        {
            //el usuario no existe (nombre equivocado)
        }
        userProfile = null;
    }
}
