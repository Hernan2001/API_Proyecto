using Proyecto_Api_Piwapp.Models;

namespace Proyecto_Api_Piwapp.Repositories
{
    public class UsuarioRepository : IFirebaseRepository<Usuario>
    {
        private readonly string CollectionName = "usuarios";
        private readonly FirebaseRepository firebaseRepository;

        public UsuarioRepository()
        {
            firebaseRepository = new FirebaseRepository(CollectionName);
        }
        public List<Usuario> GetAll() => firebaseRepository.GetAll<Usuario>(); //* list all

        public Usuario Add(Usuario model) => firebaseRepository.Add(model); //* post añadir

        public Usuario Get(Usuario model) => firebaseRepository.Get(model); //* get x id

        public bool Update(Usuario model) => firebaseRepository.Update(model); //* put actualizar x id

        public bool Delete(Usuario model) => firebaseRepository.Delete(model); //* delete x id

    }
}
