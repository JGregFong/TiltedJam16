using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<Fighter> turnOrder = new List<Fighter>();
    public int scene;
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
    private bool invincible;
    private bool invincibilityUsed = false;
    public GameObject playerAttackSound;
    public GameObject enemyAttackSound;
    public GameObject battleMusic;
    public GameObject victoryMusic;
    public GameObject lossMusic;
    public GameObject invincibleSound;
    public GameObject buffSound;

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

        StartCoroutine(Introductions());
    }

    private IEnumerator Introductions()
    {
        if (scene == 1)
        {
            dialog.text = "You like sodas? ‘Cus I’d love to “mount n’ dew” you!";
        }
        else if (scene == 2)
        {
            dialog.text = "Mom was wrong! This legal name change was worth it and now I’m invincible!";
        }
        else if (scene == 3)
        {
            dialog.text = "Baby, you’d look real good in my jet right about now.";
        }

        yield return new WaitForSeconds(3.0f);
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
            dialog.text = "Bombshell Waifu's turn.";
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
            if (invincible == false)
            {
                dialog.text = "Enemy attacks Bombshell Waifu.";
                yield return new WaitForSeconds(2.0f);
                Instantiate(enemyAttackSound);
                curEnemy.EnemyAttack();
            }
            else
            {
                dialog.text = "Enemy cannot attack because Bombshell Waifu is invincible!";
                yield return new WaitForSeconds(2.0f);
                invincible = false;
            }
            EndEnemyTurn();
        }
        else
        {
            Player p = (Player)currentFighter;
            if (attack == 1)
            {
                p.AttackOne();
                dialog.text = "Bombshell Waifu has used Waifu Giggle on the enemy.";
                yield return new WaitForSeconds(2.0f);
                Instantiate(playerAttackSound);
                EndPlayerTurn();
            }
            else if (attack == 2)
            {
                p.SetAttackModifier(0.15f);
                dialog.text = "Bombshell Waifu has used UwU and increased her damage!";
                Instantiate(buffSound);
                yield return new WaitForSeconds(2.0f);
                EndPlayerTurn();
            }
            else
            {
                invincible = true;
                invincibilityUsed = true;
                dialog.text = "Bombshell Waifu has used Bunny Nuzzle and is now invincible!";
                Instantiate(invincibleSound);
                yield return new WaitForSeconds(2.0f);
                EndPlayerTurn();
            }
        }
    }

    private void DisplayButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < 2)
            {
                buttons[i].SetActive(true);
            }
            else
            {
                if (invincibilityUsed == false)
                {
                    buttons[i].SetActive(true);
                }
            }     
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
            EndGame(false);
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
            EndGame(true);
        }
    }

    private void EndGame(bool playerWon)
    {
        battleMusic.SetActive(false);

        if (playerWon == true)
        {
            Instantiate(victoryMusic);
            if (scene == 1)
            {
                dialog.text = "So is that “mount n’ dew” still in question?";
            }
            else if (scene == 2)
            {
                dialog.text = "Wow I ship you and I harder than my OTP!";
            }
            else
            {
                dialog.text = "How about me take a trip to my private island so I can see your private islands?";
            }
        }
        else
        {
            Instantiate(lossMusic);
            if (scene == 1)
            {
                dialog.text = "Darn! I just set up my Xbox";
            }
            else if (scene == 2)
            {
                dialog.text = "Wow, I was kinda hoping you would be my senpai though";
            }
            else
            {
                dialog.text = "Alright I uh...I lied...I don’t actually have my own jet...it’s my dad’s….I applaud you m’lady";
            }
        }

        StartCoroutine(Endings());
    }

    private IEnumerator Endings()
    {
        yield return new WaitForSeconds(9.0f);
        SceneManager.LoadScene("Overworld");
    }
}
