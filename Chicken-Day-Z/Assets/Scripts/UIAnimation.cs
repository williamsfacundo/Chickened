using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ChickenDayZ.Animations 
{
    public class UIAnimation : MonoBehaviour
    {
        [SerializeField] private Image m_Image;

        [SerializeField] private Sprite[] m_SpriteArray;

        [SerializeField] private float m_Speed;

        private int m_IndexSprite;

        Coroutine m_CorotineAnim;

        bool IsDone;        

        public void Func_PlayUIAnim()
        {
            IsDone = false;
            StartCoroutine(Func_PlayAnimUI());
        }

        public void Func_StopUIAnim()
        {
            IsDone = true;
            StopCoroutine(Func_PlayAnimUI());
        }

        IEnumerator Func_PlayAnimUI()
        {
            yield return new WaitForSeconds(m_Speed);
            if (m_IndexSprite >= m_SpriteArray.Length)
            {
                m_IndexSprite = 0;
            }
            m_Image.sprite = m_SpriteArray[m_IndexSprite];
            m_IndexSprite += 1;
            if (IsDone == false)
                m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        }
    }
}