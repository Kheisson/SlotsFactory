using System;
using GizmoSlots;

namespace Infrastructure
{
    public interface IResultGenerator
    {
        void GenerateSpinResult(IResultReceiver[] resultReceivers);
    }
}