using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;
using System.Collections;

public class ShootPool : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public int poolSize = 20;
    public int currentAmmo;
    private int activeProjectiles = 0;
    private ObjectPool<GameObject> pool;
    private bool reloading = false;

    void Awake()
    {
        currentAmmo = poolSize;
        pool = new ObjectPool<GameObject>(
                () => Instantiate(projectilePrefab),
                projectile => projectile.SetActive(true),
                projectile => projectile.SetActive(false),
                projectile => Destroy(projectile),
                false,
                poolSize,
                poolSize
                );
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
        if (Keyboard.current[Key.R].wasPressedThisFrame && currentAmmo <= poolSize && !reloading)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0 || activeProjectiles >= poolSize)
        {
            return;
        }

        GameObject projectile = pool.Get();

        currentAmmo--;
        activeProjectiles++;

        projectile.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().StartProjectile(firePoint.forward, this);
    }

    public void ReturnProjectile(GameObject projectile)
    {
        activeProjectiles--;
        pool.Release(projectile);
    }

    IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("Recarregando. . .");

        yield return new WaitForSeconds(2f);
        currentAmmo = poolSize;

        Debug.Log("Recarregou! Mete bala");
        reloading = false;
    }
}
