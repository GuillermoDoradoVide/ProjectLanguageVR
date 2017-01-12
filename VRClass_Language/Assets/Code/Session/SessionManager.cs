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
        List<AchievementData> achievementList = new List<AchievementData>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        else {
            FileStream file = File.Create(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA");
            userData.userID = usersIDCount;
            bf.Serialize(file, userData);
            file.Close();
        }
        userData = null;
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

    private void saveUserProfile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        UserProfile userProfile = new UserProfile();
        if (File.Exists(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA", FileMode.Open);
            bf.Serialize(file, userProfile);
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "USER_" + usersIDCount + "_GAMEDATA");
            userProfile.userID = usersIDCount;
            userProfile.userName = "Name";
            userProfile.userPassWord = "PassWord";
            bf.Serialize(file, userProfile);
            file.Close();
        }
        userProfile = null;
    }

    private void loadUserProfileAndData(string name, string password)
    {
        if (checkUserProfileData())
        {
            if (File.Exists(Application.persistentDataPath + ""))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "", FileMode.Open);
                UserGameData userData = (UserGameData)bf.Deserialize(file);
                file.Close();
                usersIDCount = userData.userID;
                loadUserGameData();
            }
        }
        else
        {
            //EventManager.triggerEvent(Events.EventList.USERV_WRONG_USER);
        }
    }

    private bool checkUserProfileData()
    {
        return true;
    }
}
