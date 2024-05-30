using UnityEngine;

public class Tank : MonoBehaviour
{
	public Target target;
	public Turret turret;

	void Reset()
	{
		turret = GetComponentInChildren<Turret>();
	}

	void Update()
	{
		if (target != null)
		{
			turret.Aim(target);
		}
	}
}
