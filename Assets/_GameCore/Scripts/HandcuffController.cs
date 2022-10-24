using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace _GameCore.Scripts
{
   public class HandcuffController : MonoBehaviour
   {
      private void OnEnable()
      {
         
      }

      private void OnDisable()
      {
         
      }

      private void OnTriggerEnter(Collider other)
      {
         if (!other.CompareTag("Player")) return;
         
         gameObject.GetComponent<BoxCollider>().enabled = false;
         
         MoveToPolice();
      }

      private void MoveToPolice()
      {
         PoliceController.Instance.characterCarryHandcuffsList.Add(gameObject);
         PoliceController.Instance.SetEmpySlotPos();
         MoveHandcuff(PoliceController.Instance.handcuffSlotObj, PoliceController.Instance.handcuffSlotObjXPos);
      }
      
      public void MoveToThief()
      {
         ThiefController.Instance.characterCarryHandcuffsList.Add(gameObject);
         MoveHandcuff(ThiefController.Instance.handcuffSlotObj, 0);
      }

      private void MoveHandcuff(GameObject target , float parentXPos)
      {
         Sequence moveSequence = DOTween.Sequence();
         
         var obj = gameObject;
         
         obj.transform.parent = target.transform;
         
         var localPosition = target.transform.localPosition;
         var position = obj.transform.localPosition;
         
         moveSequence.Append(obj.transform.DOLocalMove(new Vector3(
            2,
            position.y,
            position.z
         ), 1).SetEase(Ease.OutCirc));
         
         moveSequence.Append( obj.transform.DOLocalMove(new Vector3(
            parentXPos,
            localPosition.y,
            localPosition.z
         ),1));

         obj.transform.rotation = target.transform.rotation;
      }
   }
}
