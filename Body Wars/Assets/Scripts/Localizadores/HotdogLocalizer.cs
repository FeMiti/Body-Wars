using UnityEngine;

public class HotdogLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 2)
        {
            localizador.frutaPlayer=2;
            localizador.SetSpawn();
        }
    }
}
