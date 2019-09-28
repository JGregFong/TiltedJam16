using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter
{
    float health;
    int baseAttack;
    float attackModifier;

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
