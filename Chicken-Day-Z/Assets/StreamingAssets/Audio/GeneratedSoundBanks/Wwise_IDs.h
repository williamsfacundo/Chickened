/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_BGM = 3126765036U;
        static const AkUniqueID PLAY_CHICKENBEINGHIT = 1307705531U;
        static const AkUniqueID PLAY_CHICKENDEATH = 3167060539U;
        static const AkUniqueID PLAY_EGGBEINGHIT = 946859409U;
        static const AkUniqueID PLAY_EGGBROKEN = 3776342762U;
        static const AkUniqueID PLAY_FOOSTEPS = 1946716263U;
        static const AkUniqueID PLAY_PISTOL_LV1 = 1493776129U;
        static const AkUniqueID PLAY_PISTOL_RELOAD_LV1 = 183297547U;
        static const AkUniqueID PLAY_ZOMBIES_DIE = 16750680U;
        static const AkUniqueID PLAY_ZOMBIES_IMPACT = 297923524U;
        static const AkUniqueID STOP_BGM = 1073466678U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSICREGION
        {
            static const AkUniqueID GROUP = 239549482U;

            namespace STATE
            {
                static const AkUniqueID GAMEOVER = 4158285989U;
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID INTRO = 1125500713U;
                static const AkUniqueID MAINMENU = 3604647259U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSICREGION

    } // namespace STATES

    namespace SWITCHES
    {
        namespace CURRENTROUNDSTATE
        {
            static const AkUniqueID GROUP = 1792748095U;

            namespace SWITCH
            {
                static const AkUniqueID BETWEENROUNDS = 932640364U;
                static const AkUniqueID INAROUND = 3867762031U;
            } // namespace SWITCH
        } // namespace CURRENTROUNDSTATE

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID EGGHEALTH = 1594264742U;
        static const AkUniqueID MUSICVOLUMEINGAMEOPTION = 1871523704U;
        static const AkUniqueID PLAYERHEALTH = 151362964U;
        static const AkUniqueID SFXVOLUMEINGAMEOPTION = 2704578016U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAINSOUNDBANK = 534561221U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
