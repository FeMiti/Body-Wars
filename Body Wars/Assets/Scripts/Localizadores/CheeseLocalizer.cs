using UnityEngine;

public class CheeseLocalizer : MonoBehaviour
{
    [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 3)
        {
            localizador.frutaPlayer=3;
            localizador.SetSpawn();
        }
    }
}
