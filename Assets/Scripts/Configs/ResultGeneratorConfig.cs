using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Gizmo Slots/Configs/Result Generator", fileName = "Result Generator")]
    public class ResultGeneratorConfig : ScriptableObject
    {
        #region Internals
        
        public enum GeneratorType
        {
            Local,
            RandomOrg
        }
        
        #endregion

        [SerializeField]
        private GeneratorType _resultGeneratorType;

        public GeneratorType ResultResultGeneratorType => _resultGeneratorType;
    }
}