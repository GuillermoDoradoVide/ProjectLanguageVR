using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IRotation : IEventSystemHandler
{
    void rotateElement(Vector2 rotation);
}
