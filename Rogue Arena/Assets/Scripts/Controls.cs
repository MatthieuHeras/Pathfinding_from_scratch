using UnityEngine;
using System.Collections.Generic;

public class Controls : MonoBehaviour
{
    protected Unit player;

    protected virtual void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Q))
                player.Move(5);
            else if (Input.GetKey(KeyCode.D))
                player.Move(7);
            else
                player.Move(6);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.Q))
                player.Move(3);
            else if (Input.GetKey(KeyCode.D))
                player.Move(1);
            else
                player.Move(2);
        }
        else if (Input.GetKey(KeyCode.Q))
            player.Move(4);
        else if (Input.GetKey(KeyCode.D))
            player.Move(0);

        if (Input.GetKeyDown(KeyCode.Y))
            player.Hit(10, 1);
    }
}
