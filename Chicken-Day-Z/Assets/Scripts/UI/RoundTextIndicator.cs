using TMPro;
using UnityEngine;

namespace ChickenDayZ.UI 
{
    [RequireComponent(typeof(RoundFrameAnimation))]
    public class RoundTextIndicator : MonoBehaviour
    {       
        [SerializeField] private TMP_Text _showRoundText;

        [SerializeField] private string _RoundText;

        private RoundFrameAnimation _roundFrameAnimation;        
        
        private void Awake()
        {
            _roundFrameAnimation = GetComponent<RoundFrameAnimation>();

            HideRoundText();
        }

        void Start()
        {
            _roundFrameAnimation.OnShowTextIndex += ShowRoundText;

            _roundFrameAnimation.OnHideTextIndex += HideRoundText;
        }         

        void OnDestroy()
        {
            _roundFrameAnimation.OnShowTextIndex -= ShowRoundText;

            _roundFrameAnimation.OnHideTextIndex -= HideRoundText;
        }

        private void ShowRoundText(string round)
        {
            _showRoundText.text = _RoundText + round;
        }

        private void HideRoundText() 
        {
            _showRoundText.text = string.Empty;
        }
    }
}