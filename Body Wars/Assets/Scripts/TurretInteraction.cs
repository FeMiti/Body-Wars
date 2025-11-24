using UnityEngine;

public class TurretInteraction : MonoBehaviour
{

    [Header("Propriedades Torretas")]
    private bool playerNearTurret=false;
    public bool podeAtirar=false;

    [SerializeField] private BossHealth vidaBoss;
    [SerializeField] private Animator animador;
    [SerializeField] private ParticleSystem muzzle;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
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
                PlayClip(1);
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
        if(muzzle!=null)
            muzzle.Play();
        PlayClip(0);
        vidaBoss.BossTakeDamage(20);
        podeAtirar=false;
    }

    private void PlayClip(int clip)
    {
        source.PlayOneShot(clips[clip]);
    }
}
