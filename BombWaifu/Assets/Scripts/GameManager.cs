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

    private void Start()
    {
        player = new Player(playerHealth, playerAttackPower);
        enemy = new Enemy(enemyHealth, enemyAttackPower);

        Debug.Log(enemy.GetType());

        int rand = Random.Range(0, 2);
        Debug.Log(rand);

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
            Debug.Log("Enemy's turn.");
            Enemy curEnemy = (Enemy) currentFighter;
            curEnemy.SetPlayer(player);
            curEnemy.EnemyAttack();
            EndEnemyTurn();
        }
        else
        {
            Debug.Log("Player's turn.");
            Player curPlayer = (Player) currentFighter;
            curPlayer.SetEnemy(enemy);
            DisplayButtons();
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
        p.AttackOne();
        EndPlayerTurn();
    }

    public void AttackTwo()
    {
        Player p = (Player)player;
        p.AttackTwo();
        EndPlayerTurn();
    }

    public void AttackThree()
    {
        Player p = (Player)player;
        p.AttackThree();
        EndPlayerTurn();
    }

    private void EndEnemyTurn()
    {
        Player p = (Player)player;
        if (p.GetHealth() > 0)
        {
            turnOrder.RemoveAt(0);
            turnOrder.Add(enemy);
            StartGame();
        }
        else
        {
            EndGame(p.GetHealth());
        }
    }

    private void EndPlayerTurn()
    {
        Enemy e = (Enemy)enemy;
        if (e.GetHealth() > 0)
        {
            turnOrder.RemoveAt(0);
            turnOrder.Add(player);
            StartGame();
        }
        else
        {
            EndGame(e.GetHealth());
        }
    }

    private void EndGame(float endHealth)
    {
        Debug.Log(endHealth);
    }
}
