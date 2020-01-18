using UnityEngine;

public class AragornControls : Controls
{

    private void Start()
    {
        player = GetComponent<Aragorn>();
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.I))
            ((Aragorn)player).weapon.Hit();

        if (Input.GetKeyDown(KeyCode.O))
            ((Aragorn)player).weapon.Shield();
        if (Input.GetKeyUp(KeyCode.O))
            ((Aragorn)player).weapon.UnShield();
    }
    
}
