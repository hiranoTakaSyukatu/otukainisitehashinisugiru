using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

namespace Connector
{
    namespace Player
    {
        public interface IObjectRecevetable
        {
            // �����蔻�肩�瓖�����������擾����C���^�[�t�F�[�X
            void ObjectRecevetable(TouchObjectType data);

            void OnPlayEventRelease();
        }
    }
}