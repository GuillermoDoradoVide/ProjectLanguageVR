using UnityEngine;
using System.Collections;

public class Start_driver_conversation : StateScript
{
    private void Start() {}

    // Update is called once per frame
    public override void atUpdate() {}

    public override void atInit()
    {
        Debugger.printLog("Init scene: " + SceneController.Instance.getCurrentScene());
    }

    public override void atEnd() { }

    public override void atPause() {/*throw new NotImplementedException();*/}

    public override void atReadyActiveState() {/*throw new NotImplementedException();*/}
}
