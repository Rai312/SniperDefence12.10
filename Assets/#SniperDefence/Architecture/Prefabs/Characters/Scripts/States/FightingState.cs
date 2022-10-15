namespace UnitState
{
    public class FightingState : IUnitState
    {
        private Unit _unit;

        public FightingState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            _unit.transform.LookAt(_unit.Target.transform.position);

            _unit.UnitAnimator.ShowAttack();
        }

        public void Exit()
        {
            _unit.UnitAnimator.ResetTrigger();
            //if (_unit is Enemy)
            //{
            //    Enemy enemy = (Enemy)_unit;
            //    enemy.MoveToFinish();
            //}
            if (_unit is Defender)
            {
                Defender defender = (Defender)_unit;
                defender.MoveToFinish();
            }
        }

        public void FixedUpdate()
        {
        }
    }
}
