using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	public Transform bombPrefab;
	
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRateShot = 0.25f;
	public float shootingRateBomb = 0.4f;
	
	//--------------------------------
	// 2 - Cooldown
	//--------------------------------
	
	private float shootCooldown;

	private bool isShot = true;

	public bool IsShot
	{
		get
		{
			//Some other code
			return isShot;
		}
		set
		{
			//Some other code
			isShot = value;
		}
	}
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{


			if (isShot)
			{
				shootCooldown = shootingRateShot;
				// Create a new shot
				var shotTransform = Instantiate(shotPrefab) as Transform;
				shotTransform.transform.parent = GameObject.Find("Canvas").transform;
				
				// Assign position
				shotTransform.position = transform.position;
				
				// The is enemy property
				ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
				if (shot != null)
				{
					shot.isEnemyShot = isEnemy;
				}
				MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
				GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
				for (int i = 1; i < go.Length; i++)
				{
					int left;
					if (go[i-1].transform.position.x > go[i].transform.position.x)
					{
						left = i;
						Debug.Log(left);
					}
					if (move != null)
					{
						move.direction = new Vector3(
							go[i].transform.position.x - shot.transform.position.x,
							go[i].transform.position.y - shot.transform.position.y,
							0
							); // towards in 2D space is the right of the sprite
					}
					//shot.transform.position = Vector3.MoveTowards(shot.transform.position, go[i].transform.position, 100f);
				}
			}
			else
			{

				shootCooldown = shootingRateBomb;
				// Create a new shot
				var bombTransform = Instantiate(bombPrefab) as Transform;
				bombTransform.transform.parent = GameObject.Find("Canvas").transform;
				
				// Assign position
				bombTransform.position = transform.position;
				
				// The is enemy property
				ShotScript shot = bombTransform.gameObject.GetComponent<ShotScript>();
				if (shot != null)
				{
					shot.isEnemyShot = isEnemy;
				}
				MoveScript move = bombTransform.gameObject.GetComponent<MoveScript>();
				GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
				for (int i = 1; i < go.Length; i++)
				{
					int left;
					if (go[i-1].transform.position.x > go[i].transform.position.x)
					{
						left = i;
						Debug.Log(left);
					}
					if (move != null)
					{
						move.direction = new Vector3(
							go[i].transform.position.x - shot.transform.position.x,
							go[i].transform.position.y - shot.transform.position.y,
							0
							); // towards in 2D space is the right of the sprite
					}
					//shot.transform.position = Vector3.MoveTowards(shot.transform.position, go[i].transform.position, 100f);
				}
			}

			// Make the weapon shot always towards it


		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}