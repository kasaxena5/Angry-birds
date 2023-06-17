using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SerializableIntEvent : UnityEvent<int>
{

}

public class IntEventListener : MonoBehaviour
{
	[SerializeField] private IntEvent _channel = default;

	public SerializableIntEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond(int value)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(value);
	}
}
