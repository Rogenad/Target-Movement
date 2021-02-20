using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Joystick
{
    public class JoystickBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField]
        private Image _joystickBackgroundImage;
        [SerializeField]
        private Image _joystickImage;
        [SerializeField]
        private float _offset;
        public Vector2 InputDirection { get; private set; }


        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputDirection = Vector2.zero;
            _joystickImage.rectTransform.anchoredPosition = InputDirection;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var sizeDelta = _joystickBackgroundImage.rectTransform.rect.size;
            var backgroundImageSizeX = sizeDelta.x;
            var backgroundImageSizeY = sizeDelta.y;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackgroundImage.rectTransform,
                eventData.position, eventData.pressEventCamera, out var position))
            {
                position.x /= backgroundImageSizeX;
                position.y /= backgroundImageSizeY;

                InputDirection = new Vector2(position.x, position.y);
                InputDirection = InputDirection.magnitude > 1 ? InputDirection.normalized : InputDirection;

                _joystickImage.rectTransform.anchoredPosition = new 
                    Vector2(InputDirection.x * (backgroundImageSizeX / _offset),
                        InputDirection.y * (backgroundImageSizeY / _offset));
            }
        }
    }
}
