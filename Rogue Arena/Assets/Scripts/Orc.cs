using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Unit
{
    public Sword weapon;
    public Transform player;
    public NodeGrid ground;
    public GameObject beacon;

    public override void Start()
    {
        base.Start();

        weapon = GetComponentInChildren<Sword>();
        speed = 6000;
    }

    public void Update()
    {
        /*if (player != null)
        {
            if (player.position.x + weapon.range < transform.position.x)
                Move(4);
            else if (player.position.x - weapon.range > transform.position.x)
                Move(0);
            if (player.position.y + 0.1f < transform.position.y)
                Move(6);
            else if (player.position.y - 0.1f > transform.position.y)
                Move(2);
        }*/

        if (Input.GetKeyDown(KeyCode.J))
        {
            
            
            List<Vector2> path = Astar.FindPath(transform.position, player.position, ref ground);

            foreach (Vector2 v in path)
            {
                Instantiate(beacon, new Vector3(v.x, v.y, 0), Quaternion.identity);
                //Debug.Log(v);
            }
        }
    }
}
