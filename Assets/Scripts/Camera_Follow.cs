using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    public float velocidade = 5f;

    void LateUpdate()
    {
        // Cria a posição desejada da câmera
        Vector3 posicaoDesejada = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );

        // Faz a câmera se mover suavemente até o Player
        transform.position = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            velocidade * Time.deltaTime
        );
    }
}
