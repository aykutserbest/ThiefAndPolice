using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class PoliceController : CharacterControllerBase<PoliceController>
    {
        public List<ThiefController> prisonerList  = new List<ThiefController>();

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

        public void IncreaseEmptySlotPos()
        {
            handcuffSlotObjXPos = handcuffSlotObj.transform.localPosition.y + (0.10f * m_multiplier);
            m_multiplier++;
        }
        
        public void DecreaseEmptySlotPos()
        {
            handcuffSlotObjXPos = handcuffSlotObj.transform.localPosition.y - (0.10f * m_multiplier);
            m_multiplier--;
        }
        
        private void GetThiefShackled(ThiefController nextPrisoner)
        {
            prisonerList.Add(nextPrisoner);
            var lastHandcuff = characterCarryHandcuffsList.LastOrDefault();
            if (lastHandcuff != null) lastHandcuff.GetComponent<HandcuffController>().MoveToThief(nextPrisoner);
        }

        public Transform GetTargetPrison(int id)
        {
            for (int i = 0; i < prisonerList.Count; i++)
            {
                if (prisonerList[i].id == id)
                {
                    if (i == 0) return gameObject.transform;

                    return prisonerList[i - 1].gameObject.transform;
                }
            }
            
            return gameObject.transform;
        }

        public void ClearPrisonList()
        {
            prisonerList.Clear();
        }

    }
}
