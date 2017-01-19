using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "AchievementData", menuName = "System/Achievements/AchievementsData", order =0)]
public class AchievementData : ScriptableObject {
    public AchievementKeysList.AchievementList achievementName;
    public Sprite image;
    public string description;
    public bool unlocked = false;
}
