using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public abstract class ItemAttribute : ScriptableObject {
	#if UNITY_EDITOR
	public virtual void DOLayout(){	}
	#endif
}
