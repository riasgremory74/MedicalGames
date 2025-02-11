//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//public class PlayerMovementManager : MonoBehaviour , IDragHandler
//{
//    private Image bgImg;
//    private Image joystickImg;
//    private Vector3 inputVector;
//    private Transform Player;

//    private void Start()
//    {
//        Player = GameObject.Find("Player").transform;
//        bgImg = GetComponent<Image>();
//        joystickImg = transform.GetChild(0).GetComponent<Image>();
//    }
//    public virtual void OnDrag(PointerEventData ped)
//    {
//        Vector2 pos;
//        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
//        {
//            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
//            inputVector = new Vector3(pos.x * 2, Player.position.z, Player.position.y);
//        }
//    }
//    public float Horizontal()
//    {
//        if (inputVector.x != 0)
//            return inputVector.x;
//        else
//            return Input.GetAxis("Horizontal");
        
//    }

//}