using UnityEngine;
using System.Collections;

public class Introduction_1 : StateScript
{
    public DialogScript dialog;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public override void atInit()
    {
        dialog.initDialog();
    }

    public override void atUpdate()
    {
        if (!dialog.playUpdateDialog()) EventManager.Instance.EventNextState();
    }

    public override void atPause()
    {
        dialog.pauseDialog();
    }

    public override void readyActiveState()
    {
        dialog.continueDialog();
    }
}
