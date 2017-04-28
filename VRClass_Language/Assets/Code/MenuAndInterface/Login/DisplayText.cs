using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayText : MonoBehaviour {

    public string text;
    public ShowAndHideAgentName agentName;

    private void Start()
    {
    }

    [ContextMenu("changeText")]
    public void changeText()
    {
        agentName.changeText(text);
    }
}
