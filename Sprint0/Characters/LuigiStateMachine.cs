using System;

internal class LuigiStateMachine : Sprint0.Interfaces.IStateMachine
{
    private bool facingLeft = true;
    private enum LuigiHealth { Normal, Stomped, Flipped };
    private LuigiHealth health = LuigiHealth.Normal;

    public void ChangeDirection()
    {
        facingLeft = !facingLeft;
    }

    public void BeStomped()
    {
        if (health != LuigiHealth.Stomped) // Note: the if is needed so we only do the transition once
        {
            health = LuigiHealth.Stomped;
            // Compute and construct Luigi sprite - requires if-else logic with value of health
        }
    }

    public void BeFlipped()
    {
        if (health != LuigiHealth.Flipped) // Note: the if is needed so we only do the transition once
        {
            health = LuigiHealth.Flipped;
            // Compute and construct Luigi sprite - requires if-else logic with value of health
        }
    }

    public void Update()
    {
        // if-else logic based on the current values of facingLeft and health to determine how to move
    }
}
