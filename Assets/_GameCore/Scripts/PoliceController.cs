using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class PoliceController : CharacterControllerBase<PoliceController>
    {
        public List<GameObject> prisonerList  = new List<GameObject>();
        
        //public List<GameObject> characterCarryHandcuffsList  = new List<GameObject>();
        
        public float handcuffSlotObjXPos;
        
        private float m_multiplier = 1;

        private void OnEnable()
        {
            EventManager.onShackleThief += GetThiefShackled;
        }

        private void OnDisable()
        {
            EventManager.onShackleThief -= GetThiefShackled;
        }

        public override void SetEmpySlotPos()
        {
            handcuffSlotObjXPos = handcuffSlotObj.transform.localPosition.y + (0.10f * m_multiplier);
            m_multiplier++;
        }
        
        private void GetThiefShackled(GameObject nextPrisoner)
        {
            prisonerList.Add(nextPrisoner);
            var lastHandcuff = characterCarryHandcuffsList.LastOrDefault();
            if (lastHandcuff != null) lastHandcuff.GetComponent<HandcuffController>().MoveToThief(nextPrisoner);
        }
    }
    
    
}
