using System;
using GizmoSlots.CoinShop;
using GizmoSlots.Models;
using GizmoSlots.NotEnoughPopup;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GizmoSlots
{
    public class PopupManager : MonoBehaviour, IPopupManager
    {
        #region Editor

        [SerializeField]
        private Transform _popupsParentTransform;

        [Header("Paytable Popup")]
        [SerializeField]
        private Object _paytablePopupPrefabRef;
        [SerializeField]
        private PaytablePopupModel _paytablePopupModel;

        [Header("Leaderboards Popup")]
        [SerializeField]
        private Object _leaderboardsPopupPrefabRef;

        [Header("Not Enough Coins")]
        [SerializeField]
        private Object _notEnoughCoinsPopupPrefabRef;

        [Header("Coin Shop")] 
        [SerializeField] 
        private Object _coinShopPopupPrefabRef;

        [Header("Player Modal")] 
        [SerializeField]
        private PlayerModel _playerModel;
        #endregion

        #region Fields

        private static PopupManager _instance;

        private PaytablePopupFactory _paytablePopupFactory;

        private PaytablePopupController _paytablePopupControllerInstance;

        private NotEnoughCoinsPopupFactory _notEnoughCoinsPopupFactory;

        private NotEnoughCoinsPopupController _notEnoughCoinsPopupControllerInstance;

        private CoinShopPopupFactory _coinShopPopupFactory;

        private CoinShopPopupController _coinShopPopupControllerInstance;
        
        #endregion
        
        #region Methods

        private void Awake()
        {
            _instance = this;
            Initialize();
            DontDestroyOnLoad(gameObject);
        }

        private void Initialize()
        {
            _paytablePopupFactory = new PaytablePopupFactory(_paytablePopupPrefabRef);
            _notEnoughCoinsPopupFactory = new NotEnoughCoinsPopupFactory(_notEnoughCoinsPopupPrefabRef);
            _coinShopPopupFactory = new CoinShopPopupFactory(_coinShopPopupPrefabRef);
        }

        public void ShowPaytablePopup()
        {
            if (_paytablePopupControllerInstance is null)
            {
                _paytablePopupControllerInstance = _paytablePopupFactory.Create(_popupsParentTransform, _paytablePopupModel);
            }

            _paytablePopupControllerInstance.ShowPopup();

        }

        public void ShowNotEnoughCoinsPopup()
        {
            if (_notEnoughCoinsPopupControllerInstance is null)
            {
                _notEnoughCoinsPopupControllerInstance = _notEnoughCoinsPopupFactory.Create(_popupsParentTransform);
            }
            _notEnoughCoinsPopupControllerInstance.ShowPopup();
        }

        public void ShowCoinShopPopup()
        {
            if (_coinShopPopupControllerInstance is null)
            {
                _coinShopPopupControllerInstance = _coinShopPopupFactory.Create(_popupsParentTransform, _playerModel);
            }
            _coinShopPopupControllerInstance.ShowPopup();
        }

        #endregion
        
        #region Properties

        public static IPopupManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Popup Manager is not ready yet");
                }

                return _instance;
            }
        }

        #endregion
    }
}