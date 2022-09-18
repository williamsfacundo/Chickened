namespace ChickenDayZ.Gameplay.Characters.Chicken.Movement.Input
{    
    public class AxisMovement
    {
        private string _horizontalMoveAxisName;

        private string _verticalMoveAxisName;

        public AxisMovement(string horizontalMoveAxisName, string verticalMoveAxisName) 
        {
            _horizontalMoveAxisName = horizontalMoveAxisName;

            _verticalMoveAxisName = verticalMoveAxisName;
        }

        public float GetHorizontalInputDetection() 
        {
            return UnityEngine.Input.GetAxisRaw(_horizontalMoveAxisName);
        }

        public float GetVerticalInputDetection()
        {
            return UnityEngine.Input.GetAxisRaw(_verticalMoveAxisName);
        }
    }
}