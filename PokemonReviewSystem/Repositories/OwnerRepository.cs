using PokemonReviewSystem.Data;
using PokemonReviewSystem.Interfaces;
using PokemonReviewSystem.Models;
using System.Diagnostics.Metrics;

namespace PokemonReviewSystem.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        public ICollection<Owner> GetOwnersOfAPokemon(int pokemonId)
        {
            return _context.PokemonOwners.Where(po => po.Pokemon.Id == pokemonId).Select(po => po.Owner).OrderBy(o => o.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int id)
        {
            return _context.PokemonOwners.Where(po => po.Owner.Id == id).Select(po => po.Pokemon).OrderBy(p => p.Id).ToList();
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(o => o.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.ChangeTracker.Clear();
            _context.Update(owner);
            return Save();
        }
    }
}
