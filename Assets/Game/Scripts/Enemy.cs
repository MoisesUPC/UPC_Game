using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speedX;

    private float limitLeft;
    private float limitRight;
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // El padre de Enemy (EnemySpace) se encarga de inicializar.
    public void StartEnemy(float limitLeft, float limitRight)
    {
        this.limitLeft = limitLeft;
        this.limitRight = limitRight;
    }

    // Update is called once per frame
    void Update()
    {
        float posX = transform.localPosition.x;
        if (posX < limitLeft && speedX < 0 || posX > limitRight && speedX > 0)
        {
            speedX *= -1;
        }
        body.linearVelocityX = speedX;
        sprite.flipX = speedX < 0 ? true : false;
    }
}
