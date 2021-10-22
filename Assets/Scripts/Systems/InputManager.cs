using Scripts.Behaviours;
using Scripts.Entities;
using UnityEngine;

namespace Scripts.Systems
{
    public class InputManager : MonoBehaviour
    { 
        public GameObject Target;
        public ILook Controller { get; set; }
        private Camera mainCamera;
        private bool useMouse;//used to remove the need of checking Target every frame(performance critical move)
        private void Start()
        {
            Controller = Transform.FindObjectOfType<Eye>();
            mainCamera = Camera.main;
            if (Target == null)
                useMouse = true;
        }

        private void Update()
        {
            if (useMouse)
                Controller.LookAtPosition(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            else
                Controller.LookAtPosition(Target.transform.position);
        }
    }
}

