using System;
using UnityEngine;

namespace GizmoSlots.NotEnoughPopup
{
    public class NotEnoughCoinsPopupView : MonoBehaviour
    {
        #region Events

        public event Action OkButtonClick;

        #endregion
        
        #region Methods

        public void OnOkButtonClick()
        {
            OkButtonClick?.Invoke();
        }

        #endregion
    }
}