using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IMenu : IEventSystemHandler
{
	void closeMenu ();
	void selectMenu ();
	void hoverMenu();
	void resetMenu();

}

