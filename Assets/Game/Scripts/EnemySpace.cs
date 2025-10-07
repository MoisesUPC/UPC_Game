using UnityEngine;

public class EnemySpace : MonoBehaviour
{
    [SerializeField] private Enemy enemyReference;
    [SerializeField] private Transform limit1;
    [SerializeField] private Transform limit2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Podemos cargar al enemigo con script
        float leftX = Mathf.Min(limit1.localPosition.x, limit2.localPosition.x);
        float rightX = Mathf.Max(limit1.localPosition.x, limit2.localPosition.x);
        enemyReference.StartEnemy(leftX, rightX);
    }
}
