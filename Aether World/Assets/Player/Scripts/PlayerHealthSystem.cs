using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    public int maxAether;
    public int currentAether;
    private GameObject player;
    public Slider healthSlider;
    public Slider healthEffectSlider;
    [SerializeField] private float healthEffectSpeed;
    public Slider aetherSlider;
    public Slider aetherEffectSlider;
    [SerializeField] private float aetherEffectSpeed;
    public float aetherRegenRate;
    public float healthRegenRate;
    [HideInInspector] public bool isDying;
    private PlayerMovement pm;

    private AquaAegis aAegis;
    public LevelManager levelManager;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        currentAether = maxAether;
        aetherSlider.maxValue = maxAether;
        aetherSlider.value = maxAether;

        aAegis = GetComponent<AquaAegis>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            gainHealth(20);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            consumeAether(20);
        }

        if (currentHealth <= 0)
        {
            isDying = true;
            pm.animator.SetBool("IsDying", true);
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
        if(healthSlider.value < maxHealth)
        {
            //regenHealth();
        }

    }

    public void consumeAether(int amount)
    {
        currentAether -= amount;
        aetherSlider.value = currentAether;
    }

    public void regenHealth()
    {
        healthSlider.value += healthRegenRate;
        currentHealth = (int)healthSlider.value;
        Debug.Log("why");
    }

    public void regenAether()
    {
        aetherSlider.value += aetherRegenRate;
        currentAether = (int)aetherSlider.value;
    }

    public void takeDamage(int amount)
    {
        if (aAegis.isActive == false)
        {
            currentHealth -= amount;
            healthSlider.value = currentHealth;
            if (currentHealth <= 0)
            {
                //levelManager.Respawn();
                //Destroy(this.gameObject);
                SceneManager.LoadScene("TitleScreen");
            }
        }
        else
        {
            return;
        }
        
    }

    public void gainHealth(int amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }
}
