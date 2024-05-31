using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;


public class TriggerScriptWithDelay : MonoBehaviour
{
	[SerializeField] bool destroyOnTriggerEnter2D;
	[SerializeField] string tagFilter;
	[SerializeField] UnityEvent onTriggerEnter2D;

	public int delay;

	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) yield return 1;
		Debug.Log("Triggered");
		yield return new WaitForSeconds(delay);
		onTriggerEnter2D.Invoke();
		if (destroyOnTriggerEnter2D)
		{
		Destroy(gameObject);
		}
	}
}
