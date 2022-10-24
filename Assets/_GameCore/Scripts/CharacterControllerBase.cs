using System.Collections.Generic;
using UnityEngine;

namespace _GameCore.Scripts
{
    public abstract class CharacterControllerBase<T> : MonoBehaviour where T : MonoBehaviour 
    {
        public static T Instance { get; private set; }

        public List<GameObject> characterCarryHandcuffsList  = new List<GameObject>();
        
        public GameObject handcuffSlotObj;
        
        protected virtual void Awake() 
        { 
            if (Instance == null)
            {
                Instance = GetComponent<T>();         
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        public abstract void SetEmpySlotPos();

    }
}
