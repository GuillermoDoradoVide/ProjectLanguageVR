using UnityEngine;
using System.Collections;
using System;

public class idleState : StateScript {


    void Start ()
    {
        init();
        isTriggerable = false;
    }
    public override void doUpdate()
    {
        //throw new NotImplementedException();
    }
}
