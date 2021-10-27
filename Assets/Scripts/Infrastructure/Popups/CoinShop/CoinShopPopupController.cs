using GizmoSlots.Models;
using UnityEngine;

namespace GizmoSlots.CoinShop
{
    public class CoinShopPopupController
    {
        #region Fields

        private CoinShopPopupView _view;

        private GameObject _viewGameObject;

        private PlayerModel _model;

        #endregion

        #region Constructor

        public CoinShopPopupController(CoinShopPopupView view, PlayerModel model)
        {
            _view = view;
            _model = model;
            _viewGameObject = _view.gameObject;
            SubscribeToViewEvents();
        }

        #endregion

        #region Methods

        public void SubscribeToViewEvents()
        {
            _view.BuyCoinsClick -= OnBuyCoinsClick;
            _view.OkButtonClick -= OnOkButtonClick;
            _view.BuyCoinsClick += OnBuyCoinsClick;
            _view.OkButtonClick += OnOkButtonClick;
        }

        private void OnBuyCoinsClick()
        {
            _model.AddCoins(100);
        }
        
        private void OnOkButtonClick()
        {
            _viewGameObject.SetActive(false);
        }

        public void ShowPopup()
        {
            if (_viewGameObject.activeInHierarchy)
                return;
            _viewGameObject.SetActive(true);
        }

        #endregion
    }
}