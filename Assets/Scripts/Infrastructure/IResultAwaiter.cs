using GizmoSlots;

namespace Infrastructure
{
    public interface IResultAwaiter
    {
        bool HasResult { get; }

        SlotIndex ResultIndex { get; }
    }
}