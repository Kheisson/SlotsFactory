using GizmoSlots.Models;
using UnityEngine;

namespace GizmoSlots
{
    public class PaytablePopupFactory
    {
        #region Fields

        private readonly Object _popupPrefabRef;
        
        #endregion

        #region Constructors

        public PaytablePopupFactory(Object popupPrefabRef)
        {
            _popupPrefabRef = popupPrefabRef;
        }

        #endregion

        #region Methods

        public PaytablePopupController Create(Transform parentTransform, PaytablePopupModel model)
        {
            var popupInstance = (GameObject)Object.Instantiate(_popupPrefabRef, parentTransform);
            var view = popupInstance.GetComponent<PaytablePopupView>();
            return new PaytablePopupController(view, model);
        }
        
        #endregion
    }
}