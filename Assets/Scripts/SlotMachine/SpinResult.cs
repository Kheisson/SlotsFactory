using System;

namespace GizmoSlots
{
    public struct SpinResult
    {
        public SlotIndex First { get; private set; }

        public SlotIndex Second  { get; private set; }

        public SlotIndex Third  { get; private set; }

        public SpinResult(SlotIndex first, SlotIndex second, SlotIndex third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public SpinResult(int first, int second, int third)
        {
            First = (SlotIndex) first;
            Second = (SlotIndex) second;
            Third = (SlotIndex) third;
        }

        public SpinResult(int[] sourceArray)
            : this(sourceArray[0], sourceArray[1], sourceArray[2])
        {
        }
    }
}