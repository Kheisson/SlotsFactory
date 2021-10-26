using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

namespace GizmoSlots
{
    public class SlotMachineReel : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private float _spinSpeed = -5;

        #endregion

        #region Fields

        private Transform _selfTransform;

        private Coroutine _spinReelCoroutine;
    
        #endregion
    
        #region Methods

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        public void SpinUntil(IResultAwaiter resultAwaiter, Action onStartSpin, Action onStopSpin)
        {
            _spinReelCoroutine = StartCoroutine(SpinUntilInternal(resultAwaiter, onStartSpin, onStopSpin));
        }

        private void OnDestroy()
        {
            if (_spinReelCoroutine != null)
            {
                StopCoroutine(_spinReelCoroutine);
            }
        }

        private IEnumerator SpinUntilInternal(IResultAwaiter resultAwaiter, Action onStartSpin, Action onStopSpin)
        {
            yield return null;
            onStartSpin?.Invoke();
            
            while (!resultAwaiter.HasResult)
            {
                _selfTransform.RotateAround(_selfTransform.position, Vector3.right, _spinSpeed);
                yield return null;
            }

            var resultIndexInt = (int) resultAwaiter.ResultIndex;
            _selfTransform.rotation = Quaternion.Euler(45f * resultIndexInt, 0, 0);
            IsSpinning = false;
            onStopSpin?.Invoke();
        }

        #endregion

        #region Properties

        public bool IsSpinning { get; private set; }

        #endregion
    }
}