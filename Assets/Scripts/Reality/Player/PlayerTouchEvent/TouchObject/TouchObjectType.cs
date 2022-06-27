namespace Reality
{
    namespace TouchObject
    {
        // Playerが触れるとアクションが起こるものEnumのデータ

        public enum TouchObjectType
        {
            //　[1]は01を表現する為の数  [01]はステージ数　[01]はジャンル  [01]はデータベースの順番

            YANKEY      = 1_01_01_01,
            CROSSWALK_1 = 1_01_01_02,
            CROSSWALK_2 = 1_01_01_03,
            PARKING     = 1_01_01_04,
            PUDDLE      = 1_01_01_05,
            SIGNALFALL  = 1_01_01_06,
        }
    }
}