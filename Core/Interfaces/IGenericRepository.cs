namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id); // Obtener por ID
        Task<IEnumerable<T>> GetAllAsync(); // Obtener todos
        Task AddAsync(T entity); // Insertar
        void Update(T entity); // Actualizar
        void Delete(T entity); // Eliminar
        Task<int> SaveChangesAsync(); // Guardar cambios pendientes en la base de datos
    }
}
