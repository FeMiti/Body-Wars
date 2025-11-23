using UnityEngine;

public class BossTouched : MonoBehaviour
{

    [SerializeField] private PlayerController controladorPlayer;
    [SerializeField] private PlayerHealth vidaPlayer;
    [SerializeField] private PlayerLocalizer localizacao;

    private float touchDamage=10f;

    void OnTriggerEnter()
    {
        controladorPlayer.TeleportPlayer(localizacao.respawnCoordinates);
        vidaPlayer.TakeDamage(touchDamage);
    }
}

