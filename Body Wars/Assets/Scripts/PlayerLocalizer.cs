using UnityEngine;

public class PlayerLocalizer : MonoBehaviour
{

    [Header("Localizadores de Player")]
    public int frutaPlayer;
    
    /*
    0 = Hamburguer
    1 = Azeitona H-H
    2 = Hot Dog
    3 = Queijo
    4 = Azeitona Q-M
    5 = Melancia
    6 = Azeitona M-B
    7 = Banana
    */

    public Vector3 respawnCoordinates = new Vector3();

    private void Start()
    {
        frutaPlayer=0;
        SetSpawn();
    }

    public void SetSpawn()
    {
        switch (frutaPlayer)
        {
            case 0:
                respawnCoordinates.Set(23,5,3);
                break;
            case 1:
                respawnCoordinates.Set(18,4,-10);
                break;
            case 2:
                respawnCoordinates.Set(8,4,-20);
                break;
            case 3:
                respawnCoordinates.Set(-12,4,-17);
                break;
            case 4:
                respawnCoordinates.Set(-21,4,-8);
                break;
            case 5:
                respawnCoordinates.Set(-20,3,7);
                break;
            case 6:
                respawnCoordinates.Set(-4,4,19);
                break;
            case 7:
                respawnCoordinates.Set(12,3,21);
                break;
        }
    }
}
