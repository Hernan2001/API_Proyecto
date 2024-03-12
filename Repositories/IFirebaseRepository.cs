namespace Proyecto_Api_Piwapp.Repositories
{
    public interface IFirebaseRepository<T>
    {
        List<T> GetAll(); //* list all
        T Add(T model); // añadir
        T Get(T model); //* get x id
        bool Update(T model); //* actualizar
        bool Delete(T model); //*delete
    }
}
