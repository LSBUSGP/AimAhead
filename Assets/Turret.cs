using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Projectile projectile;

	void Start()
	{
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot()
	{
		while (true)
		{
			projectile.Fire(transform);
			yield return new WaitForSeconds(1);
		}
	}

	Vector3 position
	{
		get { return transform.position; }
	}

	Quaternion AimAheadOfMovingTarget(Target target)
	{
		Vector3 toTarget = target.position - position;
		Vector3 up = Vector3.Cross(toTarget, target.velocity);
		Vector3 right = Vector3.Cross(up, toTarget).normalized;
		float v = Vector3.Dot(target.velocity, right);
		float p = projectile.speed;
		float a = Mathf.Asin(v / p) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(a, up) * Quaternion.LookRotation(toTarget, up);
	}

	public void Aim(Target target)
	{
		transform.rotation = AimAheadOfMovingTarget(target);
	}
}
