using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private PlayerHealth vida;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue=vida.playerMaxHealth;
        slider.value=vida.playerCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=vida.playerCurrentHealth;
        text.text=vida.playerCurrentHealth + "/" + vida.playerMaxHealth;
    }
}
