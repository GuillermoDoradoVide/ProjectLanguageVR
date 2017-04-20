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
        STATE_Next, STATE_Pause, STATE_Continue,
        MENU_Show, MENU_Hide, MENU_Active, MENU_Select,
        MV_SubMenuA_Active, MV_SubMenuA_Hide, MV_SubMenuB_Active, MV_SubMenuB_Hide, MV_SubMenuC_Active, MV_SubMenuC_Hide, MV_Hide_Active,
        // sistema de eventos para gestionar los menus. Si se selecciona 1 se desactivan el resto.
        // opciones --> triggerEvent desactivar el resto.
        ACHIEVEMENT_TriggerUnlocked_Achievement,
        PET_NewDialog, NPC_DIALOG_FINISHED,
		PLAYER_FadeIn, PLAYER_FadeOut, PLAYER_Teleport, PLAYER_PickObject, PLAYER_Inspect,
        LEVEL_Activity_Completed, NEW_USER,
        GAMEMANAGER_Pause, GAMEMANAGER_Continue,
        Count };
}

public class AchievementKeysList : ScriptableObject {
    public enum AchievementList
    {
		FIRST_LOGGIN, SESSION_1, S1_LEVEL1, S1_LEVEL2, S1_LEVEL3, SESSION_2, S2_LEVEL1, S2_LEVEL2, S2_LEVEL3,
        Count
    };

}
