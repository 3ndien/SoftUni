using _07_InfernoInfinity.Models.Contracts;

namespace _07_InfernoInfinity.Core.Factories.Contracts
{
    public interface IGemFactory
    {
        IGem Create(string clarity, string gemType);
    }
}
