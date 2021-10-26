using System;
using GizmoSlots.Models;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Gameplay.UI
{
    public class BetMultiplierAreaView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Text _currentBetMultiplier;

        [SerializeField]
        private Text _currentSpinPrice;

        [SerializeField]
        private LevelModel _levelModel;
        
        #endregion

        #region Methods

        private void Start()
        {
            UpdateArea();
        }

        private void Awake()
        {
            _levelModel.BetMultiplierChanged += UpdateArea;
        }

        private void OnDestroy()
        {
            _levelModel.BetMultiplierChanged -= UpdateArea;
        }

        private void UpdateArea()
        {
            _currentBetMultiplier.text = _levelModel.CurrentMultiplier.ToString();
            _currentSpinPrice.text = _levelModel.SpinPrice.ToString();
        }

        #endregion
    }
}