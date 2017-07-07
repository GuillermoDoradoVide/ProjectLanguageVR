using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName="levelData", menuName="Level/LevelData", order=0)]
public class LevelData : ScriptableObject {
    [Header("Level info")]
    [TextArea]
    public string sceneInfo;
	public string[] levelObjectives;
	[TextArea]
	public string[] levelInfo;
	[Header("Audio files")]
	public AudioClip[] music;
	public AudioClip[] sounds;
}
