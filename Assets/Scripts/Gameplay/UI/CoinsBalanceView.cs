using System;
using GizmoSlots.Models;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Gameplay.UI
{
    public class CoinsBalanceView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private PlayerModel _playerModel;

        [SerializeField]
        private Text _coinsBalance;
        
        #endregion
        
        #region Methods

        private void Awake()
        {
            _playerModel.CoinsBalanceChanged += OnCoinsBalanceChanged;
        }

        private void Start()
        {
            _coinsBalance.text = _playerModel.CoinsBalance.ToString();
        }

        private void OnCoinsBalanceChanged(int fromAmount, int toAmount)
        {
            _coinsBalance.text = toAmount.ToString();
        }

        private void OnDestroy()
        {
            _playerModel.CoinsBalanceChanged -= OnCoinsBalanceChanged;
        }

        #endregion
    }
}