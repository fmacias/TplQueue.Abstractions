namespace Fmacias.TplQueue.Contracts
{
    public interface IPayloadDto
    {
        T GetPayload<T>() where T : struct, IPayload;
        IPayload GetPayload();
    }
}
