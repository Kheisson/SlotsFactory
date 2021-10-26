using GizmoSlots;
using UnityEngine;

namespace Infrastructure
{
    public class SpinResultRaceResolver : IResultReceiver, IResultAwaiter
    {
        #region Fields

        private bool _slotIndexSet;

        private SlotIndex _slotIndex;

        private float _endTime;
        
        #endregion

        #region Constructor

        public SpinResultRaceResolver(float timeDelay)
        {
            _endTime = Time.time + timeDelay;
        }

        #endregion
        
        #region Methods

        public void SetResultSlotIndex(SlotIndex resultIndex)
        {
            _slotIndex = resultIndex;
            _slotIndexSet = true;
        }

        private bool GetIsDone()
        {
            var timeDelayPassed = Time.time >= _endTime;
            return _slotIndexSet && timeDelayPassed;
        }

        #endregion
        
        #region Properties

        public bool HasResult => GetIsDone();

        public SlotIndex ResultIndex => _slotIndex;

        #endregion
    }
}