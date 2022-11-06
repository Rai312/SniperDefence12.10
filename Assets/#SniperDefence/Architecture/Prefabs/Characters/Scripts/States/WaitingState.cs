namespace UnitState
{
    public class WaitingState : IUnitState
    {
        private Unit _unit;

        public WaitingState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            _unit.UnitAnimator.ShowIdle();

            if (_unit is Defender)
            {
                Defender defender = (Defender)_unit;
                defender.MoveToFinish();
                defender.NavMeshAgent.speed = defender.Speed;
            }
        }

        public void Exit()
        {
            _unit.UnitAnimator.ResetTrigger();
        }

        public void FixedUpdate()
        {
            _unit.CheckDistanceToEnemy();
        }
    }
}
