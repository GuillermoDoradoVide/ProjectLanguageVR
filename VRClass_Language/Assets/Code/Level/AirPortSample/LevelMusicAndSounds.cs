using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName="levelSounds", menuName="Sounds/LevelSounds", order=0)]
public class LevelMusicAndSounds : ScriptableObject {

	public AudioClip[] musics;
	public AudioClip[] sounds;
}
