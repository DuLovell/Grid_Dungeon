using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject
{
    [SerializeField] int wallDamage = 2;
    [SerializeField] float restartLevelDelay = 1f;

    int health;

    // Start is called before the first frame update
    protected override void Start()
    {
        health = Manager_Game.instance.PlayerHealth;
        base.Start();
    }

    private void OnDisable()
    {
        Manager_Game.instance.PlayerHealth = health;
    }

    private void Update()
    {
        if (!Manager_Game.instance.PlayersTurn)
            return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;

        if (horizontal > 0 || vertical > 0)
            AttemptMove<Wall>(horizontal, vertical);
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        CheckIfGameOver();

        Manager_Game.instance.PlayersTurn = false;
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void CheckIfGameOver() // заменить на event систему
    {
        if (health <= 0)
            Manager_Game.instance.GameOver();
    }

    void LoseHealth(int loss)
    {
        health -= loss;
        CheckIfGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exit"))
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
    }

}
