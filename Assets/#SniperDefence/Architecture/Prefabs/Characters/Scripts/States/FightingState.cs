using UnityEngine;

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
            if (_unit is Enemy)
            {
                //Debug.Log("Fighting - Enter - " + _unit);
            }

            _unit.transform.LookAt(_unit.Target.transform.position);

            _unit.UnitAnimator.ShowAttack();
        }

        public void Exit()
        {
            _unit.UnitAnimator.ResetTrigger();
            if (_unit is Enemy)
            {
                Enemy enemy = (Enemy)_unit;
                enemy.MoveToFinish();
                //Debug.Log("Fighting - Exit - " + _unit);
            }
        }

        public void FixedUpdate()
        {
            if (_unit is Fighter)
            {
                //Debug.Log("FightState");
            }
        }
    }
}
