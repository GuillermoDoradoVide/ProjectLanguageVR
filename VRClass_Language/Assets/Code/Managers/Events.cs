﻿using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName ="EventsList", menuName ="EventsList", order =1)]
public class Events  : ScriptableObject
{
    /// <summary>
    /// [Terminology]
    /// <para>SV = StateEvent</para>
    /// <para>MV = MenuEvent</para>
    /// </summary>
    public enum EventList {
        SV_nextState, SV_pauseState, SV_continueState,
        Count };
}
