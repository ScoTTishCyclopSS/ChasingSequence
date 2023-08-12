using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DeathEvent : UnityEvent<DeathArgs>
{
}

[Serializable]
public class HitEvent : UnityEvent<HitArgs>
{
}

public class HitArgs
{
    public readonly int damage;

    public HitArgs(int damage)
    {
        this.damage = damage;
    }
}

public class DeathArgs
{
}

public class Hitable : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    public bool invincible;
    public int startHealth => _startHealth;
    public int currentHealth { get; private set; }
    private bool dead;
    public HitEvent OnHit;
    public DeathEvent OnDeath;

    public void OnEnable()
    {
        dead = false;
        currentHealth = _startHealth;
    }

    public virtual void Hit(int damage)
    {
        if (dead || invincible) return;

        currentHealth -= damage;

        OnHit?.Invoke(new HitArgs(damage));

        if (currentHealth <= 0) Death();
    }

    public void Revive()
    {
        dead = false;
        currentHealth = startHealth;
    }

    public void Heal(int hpPoint)
    {
        if (dead) return;
        currentHealth += hpPoint;

        if (currentHealth > startHealth) currentHealth = startHealth;
    }

    public void Death()
    {
        if (dead) return;
        dead = true;
        OnDeath?.Invoke(new DeathArgs());
    }
}