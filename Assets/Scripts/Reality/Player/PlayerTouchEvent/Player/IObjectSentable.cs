
namespace Reality
{
    namespace TouchObject
    {
        interface IObjectSentable
        {
            // Playerが触れたらアクションを起こすオブジェクトのジャンルを取得するインタフェース

            Signal.C_TouchObjectType.TouchObjectType GetEnum();
        }
    }
}