namespace Sprint0.Interfaces
{
    public interface ICharacterState
    {
        public void MoveRight();

        public void MoveLeft();

        public void JumpLeft();

        public void JumpRight();

        public void CrouchLeft();

        public void CrouchRight();

        public void StopLeft();

        public void StopRight();

        public void Update();
    }
}
