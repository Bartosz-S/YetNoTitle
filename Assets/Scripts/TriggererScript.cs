using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerScript : MonoBehaviour
{
	[SerializeField] bool destroyOnTriggerEnter2D;
	[SerializeField] string tagFilter;
	[SerializeField] UnityEvent onTriggerEnter2D;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
		Debug.Log("Triggered");
		onTriggerEnter2D.Invoke();
		if (destroyOnTriggerEnter2D)
		{
		Destroy(gameObject);
		}
	}
}
