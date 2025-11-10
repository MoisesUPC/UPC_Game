using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private BulletPool bulletPool;
    private InputAction attackAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameObject bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        bulletPool = bulletContainer.GetComponent<BulletPool>();

        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletPool != null)
        {
            if (attackAction.WasPressedThisFrame())
            {
                Bullet bullet = bulletPool.GetBullet();
                bullet.Activate(transform.localPosition, 40f, 5f, 3);
                bullet.gameObject.SetActive(true);
            }
        }
    }
}
