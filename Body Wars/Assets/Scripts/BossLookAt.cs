using UnityEngine;

public class BossLookAt : MonoBehaviour
{

    [Header("Referencias")]
    [SerializeField] private PlayerLocalizer playerLocalizer;

    [Header("Plataformas")]
    [SerializeField] private Transform[] plataformas;

    [Header("Configuracoes")]
    private float rotationSpeed=2f;

    // Update is called once per frame
    void Update()
    {
        int id = playerLocalizer.frutaPlayer;

        if(id<0 || id>=plataformas.Length) return;
        if(plataformas[id]==null) return;

        Vector3 direction = plataformas[id].position - transform.position;

        direction.y=0;

        if(direction.sqrMagnitude<0.01f) return;

        Quaternion targetRotation=Quaternion.LookRotation(direction);

        transform.rotation=Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
