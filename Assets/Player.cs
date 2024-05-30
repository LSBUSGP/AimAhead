using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float turnSpeed = 90;
	public float maxSpeed = 1;
	[NonSerialized] public float speed = 0;
	[NonSerialized] public Vector3 direction;
	public Vector3 velocity => direction * speed;

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, h * turnSpeed * Time.deltaTime);
		speed = Input.GetAxis("Vertical") * maxSpeed;
		direction = transform.forward;
		transform.Translate(velocity * Time.deltaTime, Space.World);
	}
}
