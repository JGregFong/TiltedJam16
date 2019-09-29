using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<Fighter> turnOrder = new List<Fighter>();
    public float playerHealth = 100;
    public float playerAttackPower = 20;
    public float enemyHealth = 100;
    public float enemyAttackPower = 20;
    private Fighter player;
    private Fighter enemy;
    public GameObject[] buttons = new GameObject[3];
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    public Text dialog;

    private void Start()
    {
        player = new Player(playerHealth, playerAttackPower);
        enemy = new Enemy(enemyHealth, enemyAttackPower);

        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            turnOrder.Add(player);
            turnOrder.Add(enemy);
        }
        else
        {
            turnOrder.Add(enemy);
            turnOrder.Add(player);
        }

        StartGame();
    }

    private void StartGame()
    {
        Fighter currentFighter = turnOrder[0];

        if (currentFighter is Enemy)
        {
            StartCoroutine(DelayDialog(currentFighter, false, 0));
            
        }
        else
        {
            dialog.text = "Player's turn.";
            Player curPlayer = (Player) currentFighter;
            curPlayer.SetEnemy(enemy);
            DisplayButtons();
        }
    }

    private IEnumerator DelayDialog(Fighter currentFighter, bool playerTurn, int attack)
    {
        if (playerTurn == false)
        {
            dialog.text = "Enemy's turn.";
            yield return new WaitForSeconds(2.0f);
            Enemy curEnemy = (Enemy)currentFighter;
            curEnemy.SetPlayer(player);
            dialog.text = "Enemy attacks player.";
            yield return new WaitForSeconds(2.0f);
            curEnemy.EnemyAttack();
            EndEnemyTurn();
        }
        else
        {
            Player p = (Player)currentFighter;
            if (attack == 1)
            {
                p.AttackOne();
                dialog.text = "Player has used Waifu Giggle on the enemy.";
                yield return new WaitForSeconds(2.0f);
                EndPlayerTurn();
            }
            else if (attack == 2)
            {
                p.AttackTwo();
                dialog.text = "Player has used UwU on the enemy.";
                yield return new WaitForSeconds(2.0f);
                EndPlayerTurn();
            }
            else
            {
                p.AttackThree();
                dialog.text = "Player has used Bunny Nuzzle on the enemy.";
                yield return new WaitForSeconds(2.0f);
                EndPlayerTurn();
            }
        }
    }

    private void DisplayButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(true);
        }
    }

    public void AttackOne()
    {
        Player p = (Player)player;
        StartCoroutine(DelayDialog(p, true, 1));
    }

    public void AttackTwo()
    {
        Player p = (Player)player;
        StartCoroutine(DelayDialog(p, true, 2));
    }

    public void AttackThree()
    {
        Player p = (Player)player;
        StartCoroutine(DelayDialog(p, true, 3));
    }

    private void EndEnemyTurn()
    {
        Player p = (Player)player;
        playerHealthBar.SetPercentage(p.GetHealth(), p.GetMaxHealth());

        if (p.GetHealth() > 0)
        {
            turnOrder.RemoveAt(0);
            turnOrder.Add(enemy);
            StartGame();
        }
        else
        {
            EndGame("Enemy has won!");
        }
    }

    private void EndPlayerTurn()
    {
        Enemy e = (Enemy)enemy;
        enemyHealthBar.SetPercentage(e.GetHealth(), e.GetMaxHealth());
        if (e.GetHealth() > 0)
        {
            turnOrder.RemoveAt(0);
            turnOrder.Add(player);
            StartGame();
        }
        else
        {
            EndGame("Player has won!");
        }
    }

    private void EndGame(string winner)
    {
        dialog.text = winner;
    }
}
