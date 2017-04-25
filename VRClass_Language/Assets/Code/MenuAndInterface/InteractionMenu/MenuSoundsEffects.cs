using UnityEngine;
using System.Collections;

public class MenuSoundsEffects : MonoBehaviour {

	public void playSoundEffect(AudioClip clip)
    {
        SoundManager.playSFX(clip);
    }
}
