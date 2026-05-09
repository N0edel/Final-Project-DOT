using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Heavyprefab;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 0.5f;
    private float _currentTime = 0.5f;
    private bool _canShoot = true;
    private bool _canShootHeavyAttack = true;
    public const float HeavyTimer = 0.75f;
    public float _HeavycurrentTime = 0.75f;
    private void Update()
    {
        TimerMethod();
        Shoot();


    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }
        if (!_canShootHeavyAttack)
        {
            _HeavycurrentTime -= Time.deltaTime;

            if (_HeavycurrentTime < 0)
            {
                _canShootHeavyAttack = true;
                _HeavycurrentTime = HeavyTimer;
            }
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            GameObject bullet = Instantiate(prefab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);

            _canShoot = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShootHeavyAttack)
        {
            Debug.Log("A");
            GameObject bullet = Instantiate(Heavyprefab, bulletSpawn.position, Quaternion.identity);

            bullet.transform.SetParent(bulletTrash);

            _canShootHeavyAttack = false;
        }
    }
}

