using GizmoSlots;
using GizmoSlots.Models;
using GizmoSlots.NotEnoughPopup;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private SlotMachine _slotMachine;

        [SerializeField]
        private PlayerModel _playerModel;

        [SerializeField]
        private LevelPaytable _paytable;

        [SerializeField]
        private LevelModel _levelModel;

        [SerializeField]
        private Text _betPriceText;

        private NotEnoughCoinsPopupView _notEnoughCoinsPopup;
        
        
        #endregion

        #region Methods

        private void Awake()
        {
            _betPriceText.text = _levelModel.SpinPrice.ToString();
        }

        public void OnSpinButtonPress()
        {
            if (_playerModel.CoinsBalance < _levelModel.SpinPrice)
            {
                PopupManager.Instance.ShowNotEnoughCoinsPopup();
                return;
            }

            if (_slotMachine.IsSpinning)
            {
                return;
            }
            _playerModel.WithdrawCoins(_levelModel.SpinPrice);
            _slotMachine.Spin(OnMachineSpinStart, OnMachineSpinEnd, null);
        }

        public void OnPaytableButtonClick()
        {
            PopupManager.Instance.ShowPaytablePopup();
        }

        public void OnCoinShopButtonClick()
        {
            PopupManager.Instance.ShowCoinShopPopup();
        }

        private void OnMachineSpinStart()
        {
            // Take money
        }

        private void OnMachineSpinEnd(SpinResult spinResult)
        {
            var win = _paytable.CalculateWin(spinResult);
            _playerModel.AddCoins(win);
        }

        #endregion
    }
}