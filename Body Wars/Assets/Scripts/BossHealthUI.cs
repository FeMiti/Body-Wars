using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{

    [SerializeField] private BossHealth vida;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue=vida.bossMaxHealth;
        slider.value=vida.bossCurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=vida.bossCurrentHealth;
        text.text=vida.bossCurrentHealth + "/" + vida.bossMaxHealth;
    }
}
