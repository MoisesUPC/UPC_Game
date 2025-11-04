using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float currentAngle;
    [SerializeField] private float speed;
    [SerializeField] private float timeToDisappear;

    private Rigidbody2D body;

    private BulletPool pool;

    private float timer;
    private bool isActive;

    public void Init(BulletPool pool)
    {
        body = GetComponent<Rigidbody2D>();
        isActive = false;

        this.pool = pool;
    }

    public void ResetBullet()
    {
        transform.position = Vector3.zero;
        body.linearVelocityX = 0f;
        body.linearVelocityY = 0f;
        isActive = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Activate(float angle, float speed, float time)
    {
        float speedX = Mathf.Cos(angle * Mathf.Deg2Rad) * speed;
        float speedY = Mathf.Sin(angle * Mathf.Deg2Rad) * speed;

        body.linearVelocityX = speedX;
        body.linearVelocityY = speedY;

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
        if (timer <= 0f)
        {
            timer = 0f;
            isActive = false;
            body.linearVelocityX = 0f;
            body.linearVelocityY = 0f;

            pool.PushBullet(this);
        }
    }
}
