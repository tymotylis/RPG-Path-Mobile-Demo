using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmmitersController : MonoBehaviour
{
	public void AddParticleSystem(GameObject prefab, Vector2 where)
	{
		GameObject instance = Instantiate(prefab, where, Quaternion.identity, transform);

		StartCoroutine(KillSystem(instance));
	}

	private IEnumerator KillSystem(GameObject system)
	{
		ParticleSystem particleSystem = system.GetComponent<ParticleSystem>();

		yield return new WaitUntil(() => !particleSystem.isPlaying);

		Destroy(system);
	}
}
