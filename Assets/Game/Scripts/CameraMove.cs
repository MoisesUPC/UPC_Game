using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform playerRef;
    private Vector3 playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Ubicamos al player con su etiqueta
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerRef = playerObject.transform;
        // Guardamos la posici�n inicial del player
        playerPos = playerRef.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Guardamos la posici�n de la c�mara.
        Vector3 pos = transform.localPosition;
        // Calculamos cu�nto se mueve el player por cada frame
        float dx = playerRef.localPosition.x - playerPos.x;
        float dy = playerRef.localPosition.y - playerPos.y;
        // Lo agregamos al movimiento de la c�mara
        transform.localPosition = new Vector3(pos.x + dx, pos.y + dy, pos.z);
        // Ac� actualizamos la posici�n del player
        playerPos = playerRef.localPosition;
    }
}
