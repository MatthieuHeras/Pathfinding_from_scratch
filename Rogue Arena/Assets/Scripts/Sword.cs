using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anm;
    public int range = 1;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    public void Hit()
    {
        anm.SetTrigger("Hit");
    }
    public void Shield()
    {
        anm.SetBool("Shield", true);
    }
    public void UnShield()
    {
        anm.SetBool("Shield", false);
    }
}
