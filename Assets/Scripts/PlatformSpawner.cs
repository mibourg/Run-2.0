using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour 
{

	float maxSpawnTimer = 2.5f;
	float spawnTimer = 2.5f;

	float speed = 7f;

	float minOffset = -1f;
	float maxOffset = 0.5f;

	public GameObject platform; 

	List<GameObject> currentPlatforms = new List<GameObject>();

	void Start() 
	{
		
	}

	void Update() 
	{
		Move();
		DecrementSpawnTimer();

		if(spawnTimer <= 0)
		{
			CreatePlatform();
			ResetSpawnTimer();
		}

		if(currentPlatforms.Count > 5)
		{
			DeletePlatform();
		}
	}

	void CreatePlatform()
	{
		Vector3 position = new Vector3(gameObject.transform.position.x + RandomOffset(), gameObject.transform.position.y + RandomOffset(), 0);
		GameObject newPlatform = Instantiate(platform, position, Quaternion.identity) as GameObject;
		currentPlatforms.Add(newPlatform);
	}

	void ResetSpawnTimer()
	{
		spawnTimer = maxSpawnTimer;
	}

	void DecrementSpawnTimer()
	{
		spawnTimer -= Time.deltaTime;
	}
		

	void DeletePlatform()
	{
		Destroy(currentPlatforms[0]);
		currentPlatforms.RemoveAt(0);
	}

	float RandomOffset()
	{
		float offset = Random.Range(minOffset, maxOffset);
		return offset;
	}

	void Move()
	{
		gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
	}
}
