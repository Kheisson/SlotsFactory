using System;
using UnityEngine;

namespace GizmoSlots.NotEnoughPopup
{
    public class NotEnoughCoinsPopupController
    {
        #region Events

        public event Action PopupClosed;
        
        #endregion
        
        #region Fields

        private NotEnoughCoinsPopupView _view;

        private GameObject _viewGameObject;
        
        #endregion
        
        #region Constructors

        public NotEnoughCoinsPopupController(NotEnoughCoinsPopupView view)
        {
            _view = view;
            _viewGameObject = _view.gameObject;
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _view.OkButtonClick -= OnOkButtonClick;
            _view.OkButtonClick += OnOkButtonClick;
        }

        private void OnOkButtonClick()
        {
            _viewGameObject.SetActive(false);
            PopupClosed?.Invoke();
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