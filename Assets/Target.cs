using UnityEngine;

[RequireComponent(typeof(Player))]
public class Target : MonoBehaviour
{
	public Player player;

	void Reset()
	{
		player = GetComponent<Player>();
	}

	public Vector3 position
	{
		get { return transform.position; }
	}

	public Vector3 velocity
	{
		get { return player.velocity; }
	}
}
