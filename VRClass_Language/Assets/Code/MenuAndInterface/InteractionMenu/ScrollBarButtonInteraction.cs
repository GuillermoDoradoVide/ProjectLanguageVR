using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollBarButtonInteraction : MonoBehaviour {
    
    public Scrollbar scrollBar;
    [Range(0, 1)]
    public float value;

    private void Awake()
    {
        value = 1.0f / scrollBar.numberOfSteps;
    }
    public void increaseValue()
    {
        scrollBar.value += value;
        if (scrollBar.value > 1) scrollBar.value = 1;
    }

    public void decreaseValue()
    {
        scrollBar.value -= value;
        if (scrollBar.value < 0) scrollBar.value = 0;
    }

    public void clickSound(AudioClip clip)
    {
        SoundManager.playSFX(clip);
    }
}
