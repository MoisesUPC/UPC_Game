using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Vector3 checkpointPosition;

    private void Start()
    {
        // Ubicamos el checkpoint usando la etiqueta
        GameObject checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        // Guardamos su posición en una variable (campo o propiedad)
        checkpointPosition = checkpoint.transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectamos la zona de muerte
        if (collision.CompareTag("DeadZone"))
        {
            Debug.Log("Detecta DeadZone...");
            // Colocamos al sapo en una posición checkpoint
            transform.localPosition = checkpointPosition;
        }
    }
}
