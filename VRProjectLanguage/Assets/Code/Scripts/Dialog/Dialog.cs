using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "DialogScript", menuName = "Assets/DialogScript", order = 2)]
public class Dialog : ScriptableObject
{
    public AudioClip audioClip;
    public AudioClip getAudioClip()
    {
        return audioClip;
    }
}
