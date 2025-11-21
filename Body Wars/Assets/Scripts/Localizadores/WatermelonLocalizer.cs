using UnityEngine;

public class WatermelonLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 5)
        {
            localizador.frutaPlayer=5;
            localizador.SetSpawn();
        }
    }
}
