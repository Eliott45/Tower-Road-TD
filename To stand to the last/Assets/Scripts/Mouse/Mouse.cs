using UnityEngine;

namespace Mouse
{
    /// <summary>
    /// Mouse controller.
    /// </summary>
    public class Mouse : MonoBehaviour
    {
        /// <summary>
        /// Input action.
        /// </summary>
        private MouseController _controls;
        private Camera _camera;
        
        private void Awake()
        {
            _controls = new MouseController();
            _camera = Camera.main; // Get main camera.
        }

        private void OnEnable()
        {
            _controls.Enable();
        }
        
        private void Start()
        {
            _controls.Mouse.Click.started += _ => Click();
        }
        
        private void Click()
        {
            var ray = _camera.ScreenPointToRay(_controls.Mouse.Position.ReadValue<Vector2>());
            var hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider == null)
            {
                BuildPanel.instance.Display(false);
                return;
            }
            BuildPanel.instance.Display(hit.collider.CompareTag("TowerSpot"));
            var click = hit.collider.gameObject.GetComponent<IClicked>();
            click?.OnClick();
        }
    }
}
