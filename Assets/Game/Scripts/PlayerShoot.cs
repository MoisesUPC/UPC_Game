using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private BulletPool bulletPool;
    private InputAction attackAction;
    private Camera cameraRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GameObject bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        bulletPool = bulletContainer.GetComponent<BulletPool>();

        attackAction = InputSystem.actions.FindAction("Attack");
        cameraRef = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletPool != null)
        {
            if (attackAction.WasPressedThisFrame())
            {
                Bullet bullet = bulletPool.GetBullet();
                Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
                Debug.Log(mouseScreenPosition);
                Vector2 position = cameraRef.ScreenToWorldPoint(mouseScreenPosition);
                Debug.Log(position);
                float playerX = transform.localPosition.x;
                float playerY = transform.localPosition.y + 0.5f;
                float angleShoot = Mathf.Atan2(position.y - playerY, position.x - playerX);
                Debug.Log(Mathf.Rad2Deg * angleShoot);
                bullet.Activate(new Vector2(playerX, playerY), angleShoot, 5f, 3);
                bullet.gameObject.SetActive(true);
            }
        }
    }
}
