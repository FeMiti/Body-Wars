using UnityEngine;

public class OliveWBLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 6)
        {
            localizador.frutaPlayer=6;
            localizador.SetSpawn();
        }
    }
}
