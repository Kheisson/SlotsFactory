using GizmoSlots;

namespace Infrastructure
{
    public class Awaiter
    {
        private SlotIndex _slotIndex;

        private bool _resolved;

        public void Resolve(SlotIndex slotIndex)
        {
            _slotIndex = slotIndex;
            _resolved = true;
        }

        public void Reset()
        {
            _resolved = false;
        }

        public SlotIndex SlotIndex => _slotIndex;

        public bool Resolved => _resolved;
    }
}