using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int lines, columns;
    public Enemy[] enemy;

    public GameController gameController;

    public Vector3 direction = Vector2.right;
    public AnimationCurve movspd;
    public Projectile missilePrefab;

    public float missileAttackRate;

    public int amountKilled { get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public int totalInvaders => this.lines * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    private void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        gameController.maxscr = totalInvaders;

        missileAttackRate = 1.0f;
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);

        for (int line = 0; line < this.lines; line++)
        {
            float width = 1.0f * (this.columns - 1);
            float height = 1.0f * (this.lines - 1);
            Vector3 centering = new Vector2(-width / 2, -height / 2);
            Vector3 linePosition = new Vector3(centering.x, centering.y + (line * 1.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {               
                Enemy invader = Instantiate(this.enemy[line], this.transform);
                invader.killed += InvaderKilled;
                Vector3 position = linePosition;
                position.x += col * 1.0f;
                invader.transform.localPosition = position;
            }
        }
    }


    private void Update()
    {
        Mov();
    }

    private void Mov()
    {
        this.transform.position += direction * this.movspd.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (direction == Vector3.right && enemy.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceLine();
            }
            else if (direction == Vector3.left && enemy.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceLine();
            }
        }
    }
    private void AdvanceLine()
    {
        direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void InvaderKilled()
    {
        this.amountKilled++;
    }

    private void MissileAttack()
    {
        foreach (Transform enemy in this.transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.missilePrefab, enemy.position, Quaternion.identity);
                break;
            }
        }

    }
}
