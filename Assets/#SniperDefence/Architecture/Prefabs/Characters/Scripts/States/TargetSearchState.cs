using UnityEngine;

namespace UnitState
{
    public class TargetSearchState : IUnitState
    {
        private Unit _unit;

        public TargetSearchState(Unit unit)
        {
            _unit = unit;
        }

        public void Enter()
        {
            if (_unit is Fighter || _unit is Shooter || _unit is Enemy)
                _unit.SetTarget();
        }

        public void Exit()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}
