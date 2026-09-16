using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float MaxHealth = 20f;
    private float CurrentHealth;
    [SerializeField] public AudioClip damageSoundC;
    [SerializeField] public AudioClip deathSoundC;

    public bool HasTakenDamage { get; set; }


    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void takeDamage(float amount)
    {
        HasTakenDamage = true;
        CurrentHealth -= amount;

        SoundFX_Manager.instance.PlaySoundFXClip(damageSoundC, transform, 1f);

        CurrentHealth -= amount;
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            Die();
            SoundFX_Manager.instance.PlaySoundFXClip(deathSoundC, transform, 1f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
