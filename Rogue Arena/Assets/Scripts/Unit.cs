using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public int speed;
    public int health = 100;
    public Rigidbody2D rb;
    public Animator anm;
    public static int bumpForce = 50;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    public void Move(int direction)
    {
        switch(direction)
        {
            case 0:
                rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case 1:
                rb.AddForce(new Vector2(speed * 0.7f * Time.deltaTime, speed * 0.7f * Time.deltaTime));
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case 2:
                rb.AddForce(new Vector2(0, speed * Time.deltaTime));
                break;
            case 3:
                rb.AddForce(new Vector2(-speed * 0.7f * Time.deltaTime, speed * 0.7f * Time.deltaTime));
                transform.rotation = new Quaternion(0, 180, 0, 0);
                break;
            case 4:
                rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
                transform.rotation = new Quaternion(0, 180, 0, 0);
                break;
            case 5:
                rb.AddForce(new Vector2(-speed * 0.7f * Time.deltaTime, -speed * 0.7f * Time.deltaTime));
                transform.rotation = new Quaternion(0, 180, 0, 0);
                break;
            case 6:
                rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
                break;
            case 7:
                rb.AddForce(new Vector2(speed * 0.7f * Time.deltaTime, -speed * 0.7f * Time.deltaTime));
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
        }
    }

    public void Hit(int damage, int direction)
    {
        this.health -= damage;
        if (health <= 0)
        {
            Die();
            return;
        }
        Bump(direction);
    }

    private void Bump(int direction)
    {
        rb.AddForce(new Vector2(bumpForce, 0), ForceMode2D.Impulse);
        anm.SetTrigger("Hit");
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}