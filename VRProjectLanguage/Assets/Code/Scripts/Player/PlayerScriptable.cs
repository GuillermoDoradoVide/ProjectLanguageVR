using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "PrefabsManagers/PlayerScriptable", order =3)]
[System.Serializable]
public class PlayerScriptable : ScriptableObject {
    public GameObject menuMainController;
    public GameObject playerCamera;
}
