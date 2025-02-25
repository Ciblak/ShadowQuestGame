using UnityEngine;
using UnityEngine.UI;

public class RoomNo : MonoBehaviour
{
    public int roomNo;
    void Start()
    {
        if(GameManager.Instance!=null) roomNo=GameManager.Instance.currentRoom; //editor errors
        GetComponent<Text>().text= $"Room: {roomNo}";
    }

}
