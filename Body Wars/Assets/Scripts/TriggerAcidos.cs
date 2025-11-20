using Unity.VisualScripting;
using UnityEngine;

public class TriggerAcidos : MonoBehaviour
{

    [SerializeField] private PlayerController controladorPlayer;
    [SerializeField] private PlayerHealth vidaPlayer;

    private float acidDamage=10f;

    void OnTriggerEnter()
    {
        controladorPlayer.TeleportPlayer(new Vector3(10,4,10));
        vidaPlayer.TakeDamage(acidDamage);
    }
}
