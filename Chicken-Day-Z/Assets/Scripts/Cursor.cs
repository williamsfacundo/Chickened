using UnityEngine;

namespace ChickenDayZ.Cursor 
{
    public class Cursor : MonoBehaviour
    {
        [SerializeField] private Texture2D _cursorPrite;

        // Start is called before the first frame update
        void Start()
        {
            //UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.SetCursor(_cursorPrite, Vector2.zero, CursorMode.ForceSoftware);            
        }        
    }
}