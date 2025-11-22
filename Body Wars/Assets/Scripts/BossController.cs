using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class BossController : MonoBehaviour
{

    [Header("Boss Settings")]
    private float attackDelay=4f;
    private float timeBetweenAttacks=1.5f;
    private float turretWindow=10f;

    [SerializeField] private TurretInteraction torretaH;
    [SerializeField] private TurretInteraction torretaC;
    [SerializeField] private TurretInteraction torretaW;
    [SerializeField] private PlayerHealth vidaPlayer;
    [SerializeField] private BossHealth vidaBoss;
    [SerializeField] private PlayerLocalizer localizacao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(BossRoutine());    
    }

    IEnumerator BossRoutine()
    {
        yield return StartCoroutine(Emerge());

        while (vidaBoss.bossCurrentHealth>0)
        {
            int numberOfAttacks = Random.Range(3,6);

            for(int i=0; i<numberOfAttacks; i++)
            {
                yield return StartCoroutine(PerformRandomAttack());
                yield return new WaitForSeconds(timeBetweenAttacks);
            }

            yield return StartCoroutine(TurretPhase());
        }
    }

    IEnumerator Emerge()
    {
        Debug.Log("Boss Emergindo");
        yield return new WaitForSeconds(3f);
    }

    IEnumerator PerformRandomAttack()
    {
        int roll = Random.Range(1,11);

        if (roll <= 7)
        {
            yield return StartCoroutine(AttackCentro());
        }
        else
        {
            yield return StartCoroutine(AttackLaterais());
        }
    }

    IEnumerator AttackCentro()
    {
        int frutaAntes=localizacao.frutaPlayer;
        Debug.Log("Boss atacando a fruta " + frutaAntes);
        
        yield return new WaitForSeconds(attackDelay);
        
        int frutaDepois=localizacao.frutaPlayer;

        if (frutaAntes == frutaDepois)
        {
            vidaPlayer.TakeDamage(10f);
        }

        yield return null;
    }

    IEnumerator AttackLaterais()
    {
        int frutaAntes=localizacao.frutaPlayer;
        int frutaAntes1=frutaAntes-1;
        if (frutaAntes1 == -1)
        {
            frutaAntes1=7;
        }
        int frutaAntes2=frutaAntes+1;
        if (frutaAntes2 == 8)
        {
            frutaAntes2=0;
        }
        Debug.Log("Boss atacando frutas " + frutaAntes1 + " e " + frutaAntes2);

        yield return new WaitForSeconds(attackDelay);

        int frutaDepois=localizacao.frutaPlayer;

        if(frutaDepois==frutaAntes1 || frutaDepois == frutaAntes2)
        {
            vidaPlayer.TakeDamage(10f);
        }

        yield return null;
    }

    IEnumerator TurretPhase()
    {
        Debug.Log("Boss vulneravel");

        torretaH.podeAtirar=true;
        torretaC.podeAtirar=true;
        torretaW.podeAtirar=true;
        float timer=0;

        while (timer < turretWindow)
        {
            if (!torretaH.podeAtirar || !torretaC.podeAtirar || !torretaW.podeAtirar)
            {
                break;
            }

            timer+=Time.deltaTime;
            yield return null;
        }

        torretaH.podeAtirar=false;
        torretaC.podeAtirar=false;
        torretaW.podeAtirar=false;

        Debug.Log(timer + " segundos se passaram");
    }
}
