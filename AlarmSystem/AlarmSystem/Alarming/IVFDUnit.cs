namespace AlarmSystem.Alarming
{
    // subject
    public interface IVFDUnit
    {
        ResponseCode Notify(string CCIR_CODE);
    }
}
