using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    public int maxAether;
    private int currentAether;
    public Slider healthSlider;
    public Slider healthEffectSlider;
    [SerializeField] private float healthEffectSpeed;
    public Slider aetherSlider;
    public Slider aetherEffectSlider;
    [SerializeField] private float aetherEffectSpeed;
    public float aetherRegenRate;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        currentAether = maxAether;
        aetherSlider.maxValue = maxAether;
        aetherSlider.value = maxAether;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            consumeAether(20);
        }



        //Health Slider Effect-----------------------------
        if (healthEffectSlider.value > healthSlider.value)
        {
            healthEffectSlider.value -= healthEffectSpeed;
        }
        else
        {
            healthEffectSlider.value = healthSlider.value;
        }
        //-------------------------------------------------

        //Aether Slider Effect-----------------------------
        if (aetherEffectSlider.value > aetherSlider.value)
        {
            aetherEffectSlider.value -= aetherEffectSpeed;
        }
        else
        {
            aetherEffectSlider.value = aetherSlider.value;
        }
        //-------------------------------------------------

        if (aetherSlider.value < maxAether)
        {
            regenAether();
        }

    }

    void consumeAether(int amount)
    {
        currentAether -= amount;
        aetherSlider.value = currentAether;
    }

    void regenAether()
    {
        aetherSlider.value += aetherRegenRate;
        currentAether = (int)aetherSlider.value;
    }

    void takeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }
}
