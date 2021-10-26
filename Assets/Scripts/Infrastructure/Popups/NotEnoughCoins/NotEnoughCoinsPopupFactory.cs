using UnityEngine;

namespace GizmoSlots.NotEnoughPopup
{
    public class NotEnoughCoinsPopupFactory
    {
        #region Fields

        private readonly Object _popupPrefabRef;

        #endregion
        
        #region Constructors

        public NotEnoughCoinsPopupFactory(Object popupPrefabRef)
        {
            _popupPrefabRef = popupPrefabRef;
        }

        #endregion

        #region Methods

        public NotEnoughCoinsPopupController Create(Transform parentTransform)
        {
            var popupInstance = (GameObject)Object.Instantiate(_popupPrefabRef, parentTransform);
            var view = popupInstance.GetComponent<NotEnoughCoinsPopupView>();
            return new NotEnoughCoinsPopupController(view);
        }

        #endregion
    }
}