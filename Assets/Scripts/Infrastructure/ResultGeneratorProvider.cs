using System;
using System.Collections.Generic;
using Configs;
using GizmoSlots;
using UnityEngine;

namespace Infrastructure
{
    public static class ResultGeneratorProvider
    {
        private static ResultGeneratorConfig _currentConfig;

        private readonly static IDictionary<ResultGeneratorConfig.GeneratorType, IResultGenerator>
            _cachedGenerators = new Dictionary<ResultGeneratorConfig.GeneratorType, IResultGenerator>();
        
        static ResultGeneratorProvider()
        {
            _currentConfig = Resources.Load<ResultGeneratorConfig>("Config/Result Generator");
        }

        public static IResultGenerator Get()
        {
            var currentType = _currentConfig.ResultResultGeneratorType;
            if (_cachedGenerators.ContainsKey(currentType))
            {
                return _cachedGenerators[currentType];
            }

            _cachedGenerators.Add(currentType, Create(currentType));
            return Get();
        }

        private static IResultGenerator Create(ResultGeneratorConfig.GeneratorType type)
        {
            switch (type)
            {
                case ResultGeneratorConfig.GeneratorType.Local:
                    return new LocalResultGenerator();
                case ResultGeneratorConfig.GeneratorType.RandomOrg:
                    return new RandomOrgResultGenerator();
                default:
                    throw new Exception("Can't create result generator. Unsupported generator type");
            }
        }
    }
}