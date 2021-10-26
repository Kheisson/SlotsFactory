using GizmoSlots.Models;
using UnityEngine;

namespace GizmoSlots
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Models/Popups/Paytable Popup Model", 
        fileName = "Paytable Popup Model")]
    public class PaytablePopupModel : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private LevelPaytable _levelPaytable;

        #endregion

        #region Properties

        public LevelPaytable Paytable => _levelPaytable;

        #endregion
    }
}