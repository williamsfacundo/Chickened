using UnityEngine;

namespace ChickenDayZ.Cursor 
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorPrite;

        [SerializeField] Vector2 _cursorPosition; //x=25 y=25      

        void Start()
        {            
            UnityEngine.Cursor.SetCursor(_cursorPrite, _cursorPosition, CursorMode.ForceSoftware);            
        }        
    }
}