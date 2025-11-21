using Unity.VisualScripting;
using UnityEngine;

public class TriggerAcidos : MonoBehaviour
{

    [SerializeField] private PlayerController controladorPlayer;
    [SerializeField] private PlayerHealth vidaPlayer;
    [SerializeField] private PlayerLocalizer localizacao;

    private float acidDamage=10f;

    void OnTriggerEnter()
    {
        controladorPlayer.TeleportPlayer(localizacao.respawnCoordinates);
        vidaPlayer.TakeDamage(acidDamage);
    }
}
