using Infrastructure;
using Random = UnityEngine.Random;

namespace GizmoSlots
{
    public class LocalResultGenerator : IResultGenerator
    {
        public void GenerateSpinResult(IResultReceiver[] resultReceivers)
        {
            resultReceivers[0].SetResultSlotIndex(GetRandomSlotIndex());
            resultReceivers[1].SetResultSlotIndex(GetRandomSlotIndex());
            resultReceivers[2].SetResultSlotIndex(GetRandomSlotIndex());
        }

        private SlotIndex GetRandomSlotIndex()
        {
            return (SlotIndex) Random.Range(0, 8);
        }
    }
}