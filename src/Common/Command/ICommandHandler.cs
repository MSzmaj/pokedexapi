using System.Threading.Tasks;

namespace PokedexApi.Common.Command {
    public interface ICommandHandler<T>
    {
       Task HandleAsync(T command);
    }
}