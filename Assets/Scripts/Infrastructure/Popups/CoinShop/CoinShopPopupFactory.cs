using System;
using GizmoSlots.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GizmoSlots.CoinShop
{
    public class CoinShopPopupFactory
    {
        #region Fields

        private readonly Object _coinShopPopupPrefabRef;

        #endregion

        #region Constructor

        public CoinShopPopupFactory(Object coinShopPopupPrefabRef)
        {
            _coinShopPopupPrefabRef = coinShopPopupPrefabRef;
        }

        #endregion
        
        #region Methods

        public CoinShopPopupController Create(Transform parentTransform, PlayerModel model)
        {
            var popupInstance = (GameObject)Object.Instantiate(_coinShopPopupPrefabRef, parentTransform);
            var view = popupInstance.GetComponent<CoinShopPopupView>();
            return new CoinShopPopupController(view, model);
        }

        #endregion
    }
}