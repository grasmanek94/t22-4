#if !__LINE__
namespace Communication.Enumerators
{
    public
#endif
    enum Actions
    {
        DEBUG_STRING = 1,
        INITIALIZE_LED_STUFF,
        CHANGE_LED_COLOR,
        REQUEST_TRAIN_TRAFFIC_UPDATE,
        TRAIN_TRAFFIC_UPDATE,
        TRAIN_CONNECTME,
        TRAIN_CONNECTIONOK,
        TRAIN_CONNECTIONFAIL,
        RP6_MOVE,
        TRAIN_I_AM_GOING_TO_NEXT_STATION
    };
#if !__LINE__
}
#endif
