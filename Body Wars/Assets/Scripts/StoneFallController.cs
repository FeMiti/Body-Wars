using System;
using UnityEngine;

public class StoneFallController : MonoBehaviour
{

    public float stoneFallSpeed=5f;
    public Action onFallEnd;
    private bool isFalling=true;
    private float groundY=0f;

    // Update is called once per frame
    void Update()
    {
        if(!isFalling) return;

        transform.position+=Vector3.down * stoneFallSpeed * Time.deltaTime;

        if(transform.position.y <= groundY)
        {
            isFalling=false;

            onFallEnd?.Invoke();

            Destroy(gameObject);
        }
    }
}
