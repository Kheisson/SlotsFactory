using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class CoroutineService
    {
        #region Internals

        private class CoroutinesCore : MonoBehaviour
        {
        }

        #endregion

        #region Fields

        private static CoroutineService _instance;

        private CoroutinesCore _core;
        
        #endregion

        #region Constructors

        private CoroutineService(CoroutinesCore core)
        {
            _core = core;
        }

        #endregion

        #region Methods

        public Coroutine StartCoroutine(IEnumerator coroutineBody)
        {
            return _core.StartCoroutine(coroutineBody);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            if (coroutine == null)
            {
                return;
            }
            _core.StopCoroutine(coroutine);
        }

        private static CoroutinesCore CreateCore()
        {
            var go = new GameObject("CoroutineCore");
            Object.DontDestroyOnLoad(go);
            return go.AddComponent<CoroutinesCore>();
        }

        #endregion
        
        #region Properties

        public static CoroutineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    var core = CreateCore();
                    _instance = new CoroutineService(core);
                }

                return _instance;
            }
        }

        #endregion
    }
}