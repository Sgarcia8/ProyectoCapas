using Core.Interfaces;

namespace Services.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
            }

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity; // Retorna la entidad después de ser guardada (útil si tiene ID auto-generado)
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "La entidad a actualizar no puede ser nula.");
            }


            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entidad con ID {id} no encontrada para actualizar.");
            }

            // Opción 1: Si 'entity' ES la instancia de 'existingEntity' que fue modificada fuera de este método.
            // No necesitas hacer nada más que esto, ya que EF Core ya está rastreando los cambios en 'existingEntity'.
            _repository.Update(existingEntity); // Simplemente marca como Modified si aún no lo está.

          

            await _repository.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entidad con ID {id} no encontrada para eliminar.");
            }
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
