using System;
using System.Collections;
using System.Linq;
using Infrastructure;
using UnityEngine;
using UnityEngine.Networking;

namespace GizmoSlots
{
    public class RandomOrgResultGenerator : IResultGenerator
    {
        #region Consts

        private const string GET_REQUEST_ADDRESS 
            = "https://www.random.org/integers/?num=3&min=0&max=7&col=1&base=10&format=plain&rnd=new";
        
        #endregion
        
        #region Methods

        public void GenerateSpinResult(IResultReceiver[] resultReceivers)
        {
            CoroutineService.Instance.StartCoroutine(GetRandomValues(resultReceivers));
        }

        private IEnumerator GetRandomValues(IResultReceiver[] resultReceivers)
        {
            using (var request = UnityWebRequest.Get(GET_REQUEST_ADDRESS))
            {
                yield return request.SendWebRequest();
                var success = string.IsNullOrEmpty(request.error);
                if (success)
                {
                    var resultText = request.downloadHandler.text;
                    var randoms = resultText.Split(new [] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    var resultArray = randoms.Select(rnd => int.Parse(rnd)).ToArray();
                    
                    resultReceivers[0].SetResultSlotIndex((SlotIndex)resultArray[0]);
                    resultReceivers[1].SetResultSlotIndex((SlotIndex)resultArray[1]);
                    resultReceivers[2].SetResultSlotIndex((SlotIndex)resultArray[2]);
                }
                else
                {
                    throw new Exception(request.error);
                }
            }
        }

        #endregion
    }
}