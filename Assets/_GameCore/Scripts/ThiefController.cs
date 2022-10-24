using System.Collections.Generic;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class ThiefController : MonoBehaviour
    {
        public List<GameObject> characterCarryHandcuffsList  = new List<GameObject>();
        
        public GameObject handcuffSlotObj;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            GameObject o;
            (o = gameObject).GetComponent<BoxCollider>().isTrigger = false;
            EventManager.onShackleThief?.Invoke(o);
        }
        
    
    }
}
