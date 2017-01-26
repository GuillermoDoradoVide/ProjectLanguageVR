using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IMove : IEventSystemHandler
{
    void setMovementParentObject(GameObject parentObject);
    void clearMovementParentObject();
}
