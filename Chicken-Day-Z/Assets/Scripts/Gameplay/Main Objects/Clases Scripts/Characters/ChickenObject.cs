using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{
    public class ChickenObject : CharacterObject
    {
        public PlayerObjectTypeEnum _definePlayersObjectTypeEnum;

        private PlayerObjectTypeEnum _playersObjectTypeEnum;

        public PlayerObjectTypeEnum PlayersObjectTypeEnum 
        {
            get 
            {
                return _playersObjectTypeEnum;
            }
        }

        void Awake()
        {
            _playersObjectTypeEnum = _definePlayersObjectTypeEnum;
        }

        private ChickenObject() : base(CharacterObjectTypeEnum.CHICKEN)
        {

        }
    }
}