using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour, IMenu {

	public delegate void DoMenuFunctions();
	public DoMenuFunctions DOONselectElement, DOONhideElement, DOONresetElement, DOONhoverElement, DOONcloseElement;

	public void selectMenu() {
		if (DOONselectElement != null)
			DOONselectElement ();
	}

	public void hideMenu() {
		if (DOONhideElement != null)
			DOONhideElement ();
	}

	public void resetMenu() {
		if (DOONresetElement != null)
			DOONresetElement ();
	}

	public void hoverMenu() {
		if (DOONhoverElement != null)
			DOONhoverElement ();
	}

	public void closeMenu() {
		if (DOONcloseElement != null)
			DOONcloseElement ();
	}
}
