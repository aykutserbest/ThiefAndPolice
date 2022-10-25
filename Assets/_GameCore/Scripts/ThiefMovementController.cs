using UnityEngine;

namespace _GameCore.Scripts
{
    public class ThiefMovementController : MonoBehaviour
    {
        private Animator _animator;
        private ThiefController _controller;
        
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        
        void Start()
        {
            _controller = gameObject.GetComponent<ThiefController>();
            _animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            var policeAnim = PoliceController.Instance.gameObject.GetComponent<CharacterMovementController>()._animator
                .GetBool(IsRunning);
            if (policeAnim && _controller._isPrison)
                StartRun();
            
            else
                StopRun();
            
        }
       
        
        private void StartRun()
        {
            _animator.SetBool(IsRunning, true);
        }
        
        private void StopRun()
        {
            _animator.SetBool(IsRunning, false);
        }
    }
}
