using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float currentAngle;
    [SerializeField] private float speed;
    [SerializeField] private float timeToDisappear;

    private Rigidbody2D body;

    private float timer;
    private bool isActive;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        timer = timeToDisappear;
        isActive = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float angle = currentAngle * Mathf.Deg2Rad;
        float speedX = Mathf.Cos(angle) * speed;
        float speedY = Mathf.Sin(angle) * speed;

        body.linearVelocityX = speedX;
        body.linearVelocityY = speedY;
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

        }

    }
}
