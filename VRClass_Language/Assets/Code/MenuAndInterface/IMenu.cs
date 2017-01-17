using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IMenu : IEventSystemHandler
{
    void closeThisMenu();
}

