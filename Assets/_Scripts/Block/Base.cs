using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERLASER;

public class Base : Block
{
    public int PlayerID;

    [SerializeField] private UIAnimator player1Win;
    [SerializeField] private UIAnimator player2Win;

    private new void Update()
    {
        if (Health <= 0)
        {
            if (PlayerID == 1 && player1Win != null)
            {
                player1Win.Animate_Pos_ToOpposite();
                Destroy(player2Win.gameObject);
            }

            if (PlayerID == 2 && player2Win != null)
            {
                player2Win.Animate_Pos_ToOpposite();
                Destroy(player1Win.gameObject);
            }
        }

        base.Update();
    }
}
