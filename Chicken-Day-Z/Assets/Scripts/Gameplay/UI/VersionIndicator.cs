using UnityEngine;
using TMPro;

namespace ChickenVSZombies.UI 
{
    public class VersionIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showVersionText;

        void Awake()
        {
            _showVersionText.text = "Version v" + Application.version;
        }
    }
}