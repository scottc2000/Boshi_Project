using System;
using Sprint0.Interfaces;
using Sprint0.Commands;
using Sprint0.Sprites;

internal class MarioStateMachine : IStateMachine
{
    private bool facingLeft = true;
    private enum MarioHealth { Normal, Stomped, Flipped };
    private MarioHealth health = MarioHealth.Normal;

    public void ChangeDirection()
    {
        facingLeft = !facingLeft;
    }

    public void CrouchingLeft()
    {
        
       
    }

    public void BeFlipped()
    {
        if (health != MarioHealth.Flipped) // Note: the if is needed so we only do the transition once
        {
            health = MarioHealth.Flipped;
            // Compute and construct Mario sprite - requires if-else logic with value of health
        }
    }

    public void Update()
    {
        // if-else logic based on the current values of facingLeft and health to determine how to move
    }
}