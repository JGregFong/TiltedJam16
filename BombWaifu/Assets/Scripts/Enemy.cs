using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    private Fighter player;
    private bool isAlive = true;

    public Enemy(float newMaxHealth, float newBaseAttack)
    {
        maxHealth = newMaxHealth;
        health = maxHealth;
        baseAttack = newBaseAttack;
        attackModifier = 1;
    }

    public void EnemyAttack()
    {
        float rand = Random.Range(0, 1);

        if (rand < 0.33)
        {
            AttackOne();
        }
        else if (rand > 0.33 && rand < 0.66)
        {
            AttackTwo();
        }
        else
        {
            AttackThree();
        }
    }

    private void AttackOne()
    {
        ModifyAttack(1);
        Attack((attackModifier * baseAttack), player);
    }

    private void AttackTwo()
    {
        ModifyAttack(0.8f);
        Attack((attackModifier * baseAttack), player);
    }

    private void AttackThree()
    {
        ModifyAttack(1.1f);
        Attack((attackModifier * baseAttack), player);
    }

    //Getters
    public float GetHealth()
    {
        return health;
    }

    public float GetBaseAttack()
    {
        return baseAttack;
    }

    //Setters
    public void SetPlayer(Fighter p)
    {
        player = p;
    }
}
