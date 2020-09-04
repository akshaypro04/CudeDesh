using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    Joystick joystickmove;
    Joystick gunRot;
    [HideInInspector] public float Move;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool fire1;
    [HideInInspector] public Vector2 GunPos;
    
    void Update()
    {
        if(GameManager.instances.getPlayerAlive())
        {
            if (joystickmove == null)
            {
                try
                {
                    joystickmove = GameObject.Find("Canvas/Controller panel/movement joystick").GetComponent<Joystick>();
                }
                catch (Exception e)
                {
                    //print("cannt find joystickmove");
                }
            }

            if (gunRot == null)
            {
                try
                {
                    gunRot = GameObject.Find("Canvas/Controller panel/Gun joystick").GetComponent<Joystick>();
                }
                catch (Exception e)
                {
                    //print("cannt find gunRot");
                }

            }

            if(joystickmove != null && gunRot != null)
            {
                Move = Input.GetAxis("Horizontal") + joystickmove.Horizontal;
                GunPos = new Vector2(gunRot.Horizontal, gunRot.Vertical);
                jump = Input.GetButtonDown("Jump");
                fire1 = Input.GetMouseButton(1);
            } 
        }
    }
}
