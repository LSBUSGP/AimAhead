using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
	public Rigidbody body;
	public float speed = 10f;

	void Reset()
	{
		body = GetComponent<Rigidbody>();
	}

	public void Fire(Transform turret)
	{
		Projectile shot = Instantiate(this, turret.position, turret.rotation);
		shot.body.velocity = turret.forward * speed;
		Destroy(shot.gameObject, 5f);
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
