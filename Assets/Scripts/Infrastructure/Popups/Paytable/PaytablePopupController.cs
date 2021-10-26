using System;
using GizmoSlots.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GizmoSlots
{
    public class PaytablePopupController
    {
        #region Events

        public event Action PopupClosed;

        #endregion
        
        #region Fields

        private PaytablePopupView _view;

        private PaytablePopupModel _model;

        private GameObject _viewGameObject;
        
        #endregion

        #region Constructors

        public PaytablePopupController(PaytablePopupView view, PaytablePopupModel model)
        {
            _view = view;
            _viewGameObject = _view.gameObject;
            _model = model;
            SubscribeToViewEvents();
            _view.SetPaytable(model.Paytable);
        }

        #endregion

        #region Methods

        private void SubscribeToViewEvents()
        {
            _view.OkButtonClick -= OnViewButtonClick;
            _view.OkButtonClick += OnViewButtonClick;
        }
        
        private void OnViewButtonClick()
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