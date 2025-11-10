using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int initialSize;

    private Stack<Bullet> bullets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bullets = new Stack<Bullet>();

        for (int i = 0; i < initialSize; i++)
        {
            Bullet bulletObj = Instantiate(bullet, transform).GetComponent<Bullet>();
            bulletObj.Init(this);
            bulletObj.gameObject.SetActive(false);
            bullets.Push(bulletObj);
        }
    }

    public Bullet GetBullet()
    {
        Bullet bulletObj;
        if (bullets.Count == 0)
        {
            // New Bullet
            bulletObj = Instantiate(bullet, transform).GetComponent<Bullet>();
            bulletObj.Init(this);
            bulletObj.gameObject.SetActive(false);
        }
        else
        {
            bulletObj = bullets.Pop();
        }

        return bulletObj;
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        bullet.ResetBullet();
        bullet.gameObject.SetActive(false);
        bullets.Push(bullet);
    }
}
