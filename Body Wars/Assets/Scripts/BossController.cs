using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System;

public class BossController : MonoBehaviour
{

    [Header("Boss Settings")]
    private float attackDelay=4f;
    private float timeBetweenAttacks=1.5f;
    private float turretWindow=10f;
    private float timeAfterShot=1.5f;
    private float emergeDuration=6f;

    [SerializeField] private TurretInteraction torretaH;
    [SerializeField] private TurretInteraction torretaC;
    [SerializeField] private TurretInteraction torretaW;
    [SerializeField] private PlayerHealth vidaPlayer;
    [SerializeField] private BossHealth vidaBoss;
    [SerializeField] private PlayerLocalizer localizacao;
    [SerializeField] private Animator animador;
    [SerializeField] private Transform[] plataformaPositions;
    [SerializeField] private GameObject pedraPrefab;
    [SerializeField] private Transform emergeStartPoint;
    [SerializeField] private Transform emergeEndPoint;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
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
            int numberOfAttacks = UnityEngine.Random.Range(3,6);

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
        float elapsedTime=0f;

        Vector3 startPos = emergeStartPoint.position;
        Vector3 endPos = emergeEndPoint.position;

        transform.position=startPos;
        PlayClip(0);

        while(elapsedTime < emergeDuration)
        {
            elapsedTime+=Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime/emergeDuration);

            float smoothT = Mathf.SmoothStep(0,1,t);

            transform.position = Vector3.Lerp(startPos, endPos, smoothT);

            yield return null;
        }

        transform.position = endPos;
    }

    IEnumerator PerformRandomAttack()
    {
        int roll = UnityEngine.Random.Range(1,11);

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
        animador.SetTrigger("attacksSolo");
        PlayClip(1);
        
        bool caiu=false;

        SpawnStone(frutaAntes,()=>caiu=true);

        yield return new WaitUntil(()=>caiu);
        
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
        int frutaAntes1 = (frutaAntes-1+8)%8;
        int frutaAntes2 = (frutaAntes+1)%8;

        animador.SetTrigger("attacksArea");
        PlayClip(2);

        bool caiu1 = false;
        bool caiu2 = false;

        SpawnStone(frutaAntes1, ()=>caiu1=true);
        SpawnStone(frutaAntes2, ()=>caiu2=true);

        yield return new WaitUntil(()=> caiu1 && caiu2);

        int frutaDepois=localizacao.frutaPlayer;

        if(frutaDepois==frutaAntes1 || frutaDepois == frutaAntes2)
        {
            vidaPlayer.TakeDamage(10f);
        }

        yield return null;
    }

    IEnumerator SpawnAndWaitStone(int frutaIndex)
    {
        bool caiu = false;
        SpawnStone(frutaIndex, () => caiu = true);
        yield return new WaitUntil(()=>caiu);
    }

    private void SpawnStone(int frutaIndex, System.Action callback)
    {
        Vector3 pos = plataformaPositions[frutaIndex].position + Vector3.up * 20f;

        GameObject pedra = Instantiate(pedraPrefab, pos, Quaternion.identity);

        var fall = pedra.GetComponent<StoneFallController>();
        fall.onFallEnd = callback;
    }

    IEnumerator TurretPhase()
    {
        Debug.Log("Boss vulneravel");

        torretaH.podeAtirar=true;
        torretaC.podeAtirar=true;
        torretaW.podeAtirar=true;
        animador.SetBool("isStunned",true);
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
        animador.SetBool("isStunned",false);
        yield return new WaitForSeconds(timeAfterShot);


    }

    private void PlayClip(int clip)
    {
        source.PlayOneShot(clips[clip]);
    }
}
