using UnityEngine;

public class HamburguerLoalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 0)
        {
            localizador.frutaPlayer=0;
            localizador.SetSpawn();
        }
    }
}
