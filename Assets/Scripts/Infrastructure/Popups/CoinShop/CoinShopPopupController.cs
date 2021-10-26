using UnityEngine;

namespace GizmoSlots.CoinShop
{
    public class CoinShopPopupController
    {
        #region Fields

        private CoinShopPopupView _view;

        private GameObject _viewGameObject;

        #endregion

        #region Constructor

        public CoinShopPopupController(CoinShopPopupView view)
        {
            _view = view;
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