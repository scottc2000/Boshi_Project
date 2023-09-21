using System;

internal class MarioStateMachine : Sprint0.Interfaces.IStateMachine
{
    private bool facingLeft = true;
    private enum MarioHealth { Normal, Stomped, Flipped };
    private MarioHealth health = MarioHealth.Normal;

    public void ChangeDirection()
    {
        facingLeft = !facingLeft;
    }

    public void BeStomped()
    {
        if (health != MarioHealth.Stomped) // Note: the if is needed so we only do the transition once
        {
            health = MarioHealth.Stomped;
            // Compute and construct Mario sprite - requires if-else logic with value of health
        }
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