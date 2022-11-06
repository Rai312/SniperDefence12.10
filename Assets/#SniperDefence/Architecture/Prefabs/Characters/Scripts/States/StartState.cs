namespace UnitState
{
    public class StartState : IUnitState
    {
        private readonly Unit _unit;

        public StartState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}