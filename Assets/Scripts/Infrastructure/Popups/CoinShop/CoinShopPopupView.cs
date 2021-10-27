using System;
using UnityEngine;

namespace GizmoSlots.CoinShop
{
    public class CoinShopPopupView : MonoBehaviour
    {
        #region Events

        public event Action BuyCoinsClick;
        public event Action OkButtonClick;

        #endregion
        
        #region Methods

        public void OnOkButtonClick()
        {
            OkButtonClick?.Invoke();
        }

        public void OnBuyCoinsClick()
        {
            BuyCoinsClick?.Invoke();
        }
        

        #endregion
    }
}