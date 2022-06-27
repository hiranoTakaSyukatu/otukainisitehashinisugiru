using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

namespace Connector
{
    namespace Player
    {
        public interface IObjectRecevetable
        {
            // 当たり判定から当たった物を取得するインターフェース
            void ObjectRecevetable(TouchObjectType data);

            void OnPlayEventRelease();
        }
    }
}