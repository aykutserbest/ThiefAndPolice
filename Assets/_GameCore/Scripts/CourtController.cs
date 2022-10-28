using System;
using System.Linq;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class CourtController : MonoBehaviour
    {
        private PoliceController _policeController;

        [SerializeField] private Transform _areaPivot;

        private void Start()
        {
            _policeController = PoliceController.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            if ( (_policeController.prisonerList!= null) && (!_policeController.prisonerList.Any())) return;

            _policeController.prisonerList[0].SetDestination(_areaPivot);

            for (int i = 0; i < _policeController.prisonerList.Count; i++)
            {
                _policeController.prisonerList[i].CourtCountdown(i+2);
            }
            _policeController.ClearPrisonList();
        }
    }
}
