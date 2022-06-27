using Reality.TouchObject;

namespace Connector
{
    namespace SaveSystem
    {
        public interface IUploadTimeReceivable
        {
            void DeadEventReceive(int enumValue);
            void ClearEventReceive(int stageNum);
        }
    }
}
