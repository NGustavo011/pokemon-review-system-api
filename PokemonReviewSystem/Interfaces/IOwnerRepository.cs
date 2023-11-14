using PokemonReviewSystem.Data;
using PokemonReviewSystem.Models;

namespace PokemonReviewSystem.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int id);
        ICollection<Owner> GetOwnersOfAPokemon(int pokemonId);
        ICollection<Pokemon> GetPokemonsByOwner(int id);
        bool OwnerExists (int id);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool Save();
    }
}
