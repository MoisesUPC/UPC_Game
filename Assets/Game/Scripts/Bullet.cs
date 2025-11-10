using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private Vector2 currentSpeed;
    private float timeToDisappear;

    private Rigidbody2D body;
    private BulletPool pool;

    private float timer;
    private bool isActive;

    public void Init(BulletPool pool)
    {
        currentSpeed = new Vector2 (0f, 0f);
        body = GetComponent<Rigidbody2D>();
        isActive = false;

        this.pool = pool;
    }

    public void ResetBullet()
    {
        transform.position = Vector3.zero;
        currentSpeed.x = 0f;
        currentSpeed.y = 0f;
        body.linearVelocityX = currentSpeed.x;
        body.linearVelocityY = currentSpeed.y;
        isActive = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Activate(Vector2 initPosition, float angle, float speed, float time)
    {
        transform.localPosition = initPosition;

        currentSpeed.x = Mathf.Cos(angle) * speed;
        currentSpeed.y = Mathf.Sin(angle) * speed;

        timeToDisappear = time;
        timer = timeToDisappear;

        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;
        timer -= Time.deltaTime;
        body.linearVelocityX = currentSpeed.x;
        body.linearVelocityY = currentSpeed.y;
        if (timer <= 0f)
        {
            timer = 0f;
            pool.ReturnBulletToPool(this);
        }
    }
}
