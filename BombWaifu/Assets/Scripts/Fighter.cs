using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter
{
    protected float health;
    protected float maxHealth;
    protected int baseAttack;
    protected float attackModifier;

    public void Attack(float dmg, Fighter opponent) {
        opponent.TakeDamage(dmg);
    }

    public void TakeDamage(float dmgTaken)
    {
        health -= dmgTaken;
    }

    public void ModifyAttack(float attackModchange)
    {
        attackModifier = attackModchange;
    }
}
