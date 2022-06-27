
namespace Virtulity
{
    namespace StageAssetManager
    {
        interface IStageAssetSettable
        {
            void SetDatebase(StageDB arborStageDB);

            bool IsVaild(int stageNum);
        }
    }
}
