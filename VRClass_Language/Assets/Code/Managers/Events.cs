using UnityEngine;
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
        MV_Show, MV_Hide, MV_Active, MV_Select,
        MV_SubMenuA_Active, MV_SubMenuA_Hide, MV_SubMenuB_Active, MV_SubMenuB_Hide, MV_SubMenuC_Active, MV_SubMenuC_Hide,
        // sistema de eventos para gestionar los menus. Si se selecciona 1 se desactivan el resto.
        // opciones --> triggerEvent desactivar el resto.
        Pet_NewDialog,
        GM_Pause,
        Count };
}
