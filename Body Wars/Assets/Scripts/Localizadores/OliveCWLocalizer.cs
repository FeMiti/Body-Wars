using UnityEngine;

public class OliveCWLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 4)
        {
            localizador.frutaPlayer=4;
            localizador.SetSpawn();
        }
    }
}
