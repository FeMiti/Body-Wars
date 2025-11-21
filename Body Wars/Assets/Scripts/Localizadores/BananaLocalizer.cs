using UnityEngine;

public class BananaLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 7)
        {
            localizador.frutaPlayer=7;
            localizador.SetSpawn();
        }
    }
}
