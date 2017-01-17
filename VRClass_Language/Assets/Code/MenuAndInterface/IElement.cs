using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IElement : IEventSystemHandler {

    void hoverElement();
    void selectElement();
    void resetElement();
}
