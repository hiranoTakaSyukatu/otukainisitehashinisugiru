namespace GameSelect
{
    namespace Model
    {
        interface ISelectAssetPrefabSettable
        {
            void SetDatebase(SelectAssetPrefabDate museumAssetDate);

            bool IsVaild();
        }
    }
}
