public readonly struct ServerResultInfo
{
    public ServerResultInfo(bool isNewUpdate)
    {
        this.isNewUpdate = isNewUpdate;
    }
    public readonly bool isNewUpdate;
}