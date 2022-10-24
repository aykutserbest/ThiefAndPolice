using System.Collections.Generic;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class ThiefController : CharacterControllerBase<ThiefController>
    {
        //public List<GameObject> characterCarryHandcuffsList  = new List<GameObject>();
        
        private void OnTriggerEnter(Collider other)
        {Debug.Log("geldi");
            if (!other.CompareTag("Player")) return;
            Debug.Log("if geçti geldi");
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            EventManager.onShackleThief?.Invoke(gameObject);
        }
        
        public override void SetEmpySlotPos()
        {
            
        }
    
    }
}
