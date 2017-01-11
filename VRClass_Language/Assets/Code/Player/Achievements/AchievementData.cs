using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "AchievementData", menuName = "System/Achievements/AchievementsData", order =0)]
public class AchievementData : ScriptableObject {

    public string achievementName;
    public Sprite image;
    public string description;
}
