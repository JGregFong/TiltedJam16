using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    Enemy(float newMaxHealth, int newBaseAttack)
    {
        maxHealth = newMaxHealth;
        health = maxHealth;
        baseAttack = newBaseAttack;
    }
}
