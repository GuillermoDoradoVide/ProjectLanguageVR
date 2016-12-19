using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "DialogScript", menuName = "Assets/DialogScript", order = 3)]
public class Dialog : ScriptableObject
{
    public AudioClip audioClip;
    public AudioClip getAudioClip()
    {
        return audioClip;
    }
}
