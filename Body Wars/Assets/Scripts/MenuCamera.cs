using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private float rotationSpeed = 9f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);
    }
}
