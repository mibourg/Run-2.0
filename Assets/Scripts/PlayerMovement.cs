using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{

	float speed = 7f;
	float jumpForce = 7f;

	float jumpRayLength = 1f;
	float sideRayLength = 1f;

	int points = 0;

	Rigidbody rb;

	// Use this for initialization
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		Move();

		if(OnSurface())
		{
			Jump();
		}

		if(Falling())
		{
			Respawn();
		}

		if(TouchingSide())
		{
			Respawn();
		}

	}

	void Move()
	{
		rb.transform.position += Vector3.right * speed * Time.deltaTime;
	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}

	void Respawn()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	bool Falling()
	{
		if(gameObject.transform.position.y <= -15)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool OnSurface()
	{
		if(Physics.Raycast(rb.transform.position, Vector3.down, jumpRayLength))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	bool TouchingSide()
	{
		if(Physics.Raycast(rb.transform.position, Vector3.right, sideRayLength))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void AddPoint()
	{
		points += 1;
	}
}
