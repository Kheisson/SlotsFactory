using System;
using Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GizmoSlots
{
    public class SlotMachine : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private SlotMachineReel[] _reels;
        
        #endregion
        
        #region Fields

        private Action<SpinResult> _onMachineSpinEnd;

        private SpinResult _lastSpinResult;

        #endregion

        #region Fields

        private SpinResultRaceResolver[] _resolvers;
        
        #endregion
        
        #region Methods

        private bool GetIsMachineSpinning()
        {
            foreach (var isReelSpinning in _reels)
            {
                if (isReelSpinning.IsSpinning)
                {
                    return true;
                }
            }
            return false;
        }

        public void Spin(Action onStart, Action<SpinResult> onEnd, Action onAlreadySpinning)
        {
            if (IsSpinning)
            {
                onAlreadySpinning?.Invoke();
                return;
            }

            _onMachineSpinEnd = onEnd;
            onStart?.Invoke();

            _resolvers = CreateAwaiters();
            SpinAllReels(OnReelSpinStart, OnReelSpinEnd);
            ResultGeneratorProvider.Get().GenerateSpinResult(_resolvers);
        }

        private SpinResultRaceResolver[] CreateAwaiters()
        {
            return new[]
            {
                new SpinResultRaceResolver(Random.Range(2.5f, 5.5f)),
                new SpinResultRaceResolver(Random.Range(2.5f, 5.5f)),
                new SpinResultRaceResolver(Random.Range(2.5f, 5.5f)),
            };
        }

        private void OnReelSpinStart()
        {
        }

        private void OnReelSpinEnd()
        {
            if (!IsSpinning)
            {
                _onMachineSpinEnd?.Invoke(_lastSpinResult);
            }
        }

        private void SpinAllReels(Action onReelSpinStart, Action onReelSpinEnd)
        {
            _reels[0].SpinUntil(_resolvers[0], onReelSpinStart, onReelSpinEnd);
            _reels[1].SpinUntil(_resolvers[1], onReelSpinStart, onReelSpinEnd);
            _reels[2].SpinUntil(_resolvers[2], onReelSpinStart, onReelSpinEnd);
        }

        #endregion
        
        #region Properties

        public bool IsSpinning => GetIsMachineSpinning();

        #endregion
    }
}