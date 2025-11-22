using UnityEngine;

public class TurretInteraction : MonoBehaviour
{

    [Header("Propriedades Torretas")]
    private bool playerNearTurret=false;
    public bool podeAtirar=false;

    [SerializeField] private BossHealth vidaBoss;
    [SerializeField] private Animator animador;
    // Update is called once per frame
    void Update()
    {
        if(playerNearTurret && Input.GetKeyDown(KeyCode.E))
        {
            if (podeAtirar)
            {
                FireTurret();
            }
            else
            {
                Debug.Log("Nao pode atirar :(");
            }
        }
    }

    private void OnTriggerEnter()
    {
        playerNearTurret=true;
    }

    private void OnTriggerExit()
    {
        playerNearTurret=false;
    }

    private void FireTurret()
    {

        animador.SetTrigger("interaction");
        Debug.Log("BUM!!!");
        vidaBoss.BossTakeDamage(20);
        podeAtirar=false;
    }
}
