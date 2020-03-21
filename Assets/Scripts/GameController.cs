using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ObjectDestroyer enemyTower;
    public ObjectDestroyer playerTower;
    public float currPlayerHealth;
    public float currEnemiesHealth;
    public float maxHealth;

    public Slider playerHealthBar;
    public Slider enemiesHealthBar;

    public static bool isPaused;

    private GameObject ShowWinner;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 70f;
        //playerHealth = 50;
        //enemiesHealth = 50;
        currPlayerHealth = maxHealth;
        currEnemiesHealth = maxHealth;
        playerHealthBar.value = CalculatedHealth(currPlayerHealth);
        enemiesHealthBar.value = CalculatedHealth(currEnemiesHealth);

        ShowWinner = GameObject.Find("PanelGameOver");
        ShowWinner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy Get Hit
        if (enemyTower.onHit)
        {
            currEnemiesHealth -= enemyTower.attack;
            enemyTower.onHit = false;
            enemiesHealthBar.value = CalculatedHealth(currEnemiesHealth);
        }

        // Player Get Hit
        if (playerTower.onHit)
        {
            currPlayerHealth -= playerTower.attack;
            playerTower.onHit = false;
            playerHealthBar.value = CalculatedHealth(currPlayerHealth);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currEnemiesHealth -= 5;
            enemiesHealthBar.value = CalculatedHealth(currEnemiesHealth);
        }

        if (currEnemiesHealth <= 0)
        {
            Time.timeScale = 0;
            isPaused = true;
            Winner("Player");
        }

        if (currPlayerHealth <= 0)
        {
            Time.timeScale = 0;
            isPaused = true;
            Winner("Enemy");
        }

    }

    float CalculatedHealth(float currentHealth)
    {
        return currentHealth / maxHealth;
    }

    public void IsPauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void BtnPlay()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Winner(string winner)
    {
        ShowWinner.SetActive(true);

        Text playerWin = GameObject.Find("TextGameOver").GetComponent<Text>();

        if (winner.Equals("Player"))
        {
            playerWin.text = "You Win";
        }
        else if (winner.Equals("Enemy"))
        {
            playerWin.text = "You Lose";
        }
    }
}
