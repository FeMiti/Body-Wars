using UnityEngine;

public class OliveHHLocalizer : MonoBehaviour
{
   [SerializeField] private PlayerLocalizer localizador;

    void OnTriggerEnter()
    {
        if (localizador.frutaPlayer != 1)
        {
            localizador.frutaPlayer=1;
            localizador.SetSpawn();
        }
    }
}
