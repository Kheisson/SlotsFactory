using System;
using GizmoSlots.Models;
using UnityEngine;

namespace GizmoSlots
{
    public class PaytablePopupView : MonoBehaviour
    {
        #region Events

        public event Action OkButtonClick;

        #endregion

        #region Editor
        
        [SerializeField]
        private PaytableElementView[] _paytableElementViews;
        
        #endregion
        
        #region Methods

        public void SetPaytable(LevelPaytable paytable)
        {
            for (var i = 0; i < _paytableElementViews.Length; i++)
            {
                var paytableElementView = _paytableElementViews[i];
                var price = paytable.GetWinBySlotIndex(paytableElementView.SlotIndex);
                paytableElementView.TextElement.text = price.ToString();
            }
        }

        public void OnOkButtonClick()
        {
            OkButtonClick?.Invoke();
        }

        #endregion
    }
}