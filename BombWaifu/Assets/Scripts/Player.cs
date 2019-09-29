using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    private Fighter enemy;
    private bool isAlive = true;

    public Player(float newMaxHealth, float newBaseAttack)
    {
        maxHealth = newMaxHealth;
        health = maxHealth;
        baseAttack = newBaseAttack;
        attackModifier = 1;
    }

    public void AttackOne()
    {
        ModifyAttack(1);
        Attack((attackModifier * baseAttack), enemy);
    }

    public void AttackTwo()
    {
        ModifyAttack(0.8f);
        Attack((attackModifier * baseAttack), enemy);
    }

    public void AttackThree()
    {
        ModifyAttack(1.1f);
        Attack((attackModifier * baseAttack), enemy);
    }

    //Getters
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    //Setters
    public void SetEnemy(Fighter e)
    {
        enemy = e;
    }
}
