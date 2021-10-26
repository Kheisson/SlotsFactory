using System;
using UnityEngine;

namespace GizmoSlots.Models
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Models/Level Model", fileName = "Level Model")]
    public class LevelModel : ScriptableObject
    {
        #region Events

        public event Action BetMultiplierChanged;

        #endregion
        
        #region Editor

        [SerializeField]
        private int _spinPrice;

        [SerializeField]
        private int[] _betMultipliers;
        
        #endregion

        #region Fields

        private int _currentBetMultiplierIndex;

        #endregion

        #region Methods

        public void IncrementMultiplier()
        {
            if (IsMultipliersEmpty())
            {
                return;
            }

            _currentBetMultiplierIndex++;
            if (_currentBetMultiplierIndex > _betMultipliers.Length - 1)
            {
                _currentBetMultiplierIndex = 0;
            }
            BetMultiplierChanged?.Invoke();
        }

        public void DecrementMultiplier()
        {
            if (IsMultipliersEmpty())
            {
                return;
            }

            _currentBetMultiplierIndex--;
            if (_currentBetMultiplierIndex < 0)
            {
                _currentBetMultiplierIndex = 0;
            }
            BetMultiplierChanged?.Invoke();
        }

        private int GetCurrentSpinPrice()
        {
            if (IsMultipliersEmpty())
            {
                return _spinPrice;
            }

            return _betMultipliers[_currentBetMultiplierIndex] * _spinPrice;
        }

        public int GetCurrentMultiplier()
        {
            if (IsMultipliersEmpty())
            {
                return 1;
            }

            return _betMultipliers[_currentBetMultiplierIndex];
        }

        private bool IsMultipliersEmpty()
        {
            return _betMultipliers == null || _betMultipliers.Length <= 0;
        }

        #endregion
        
        #region Properties

        public int SpinPrice => GetCurrentSpinPrice();

        public int CurrentMultiplier => GetCurrentMultiplier();

        #endregion
    }
}