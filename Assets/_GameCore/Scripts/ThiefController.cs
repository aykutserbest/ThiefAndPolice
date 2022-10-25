using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _GameCore.Scripts
{
    public class ThiefController : MonoBehaviour
    {
        public int id;
        
        public List<GameObject> characterCarryHandcuffsList  = new List<GameObject>();
        
        public GameObject handcuffSlotObj;

        private bool _isFollow;
        
        public bool _isPrison;

        private Transform targetPosition;

        private NavMeshAgent _thiefAgent;

        private void Start()
        {
            _thiefAgent = GetComponent<NavMeshAgent>();
        }   

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (_isPrison) return;

            _isPrison = true;
            
            EventManager.onShackleThief?.Invoke(this);

            StartFollow();
        }

        private void StartFollow()
        {
            targetPosition = PoliceController.Instance.GetTargetPrison(id);
            _isFollow = true;
        }

        private void Update()
        {
            if (_isFollow && targetPosition)
            {
                _thiefAgent.SetDestination(targetPosition.position);
            }
        }

        public void SetDestination(Transform targetPos)
        {
            targetPosition = targetPos;
        }

        public void CourtCountdown(float seconds)
        {
            StartCoroutine(DestroyThief(seconds));
        }

        private IEnumerator DestroyThief(float seconds)
        {
           yield return new WaitForSeconds(seconds);
           characterCarryHandcuffsList[0].GetComponent<HandcuffController>().MoveToPolice();
           Destroy(gameObject);
        }
    }
}
