using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "DialogScript", menuName = "DialogScript", order = 2)]
public class DialogScript : ScriptableObject
{
    public AudioClip[] audioClip;

    public AudioClip[] getAudioClip()
    {
        return audioClip;
    }
}
