using Google.Cloud.Firestore;

namespace Proyecto_Api_Piwapp.Models
{
    [FirestoreData]
    public class Usuario : FirebaseDocumentId
    {
        [FirestoreProperty]
        public string departamento { get; set; }
        [FirestoreProperty]
        public string direccion { get; set; }
        [FirestoreProperty]
        public string distrito { get; set; }
        [FirestoreProperty]
        public string fechnacimiento { get; set; }
        [FirestoreProperty]
        public string genero { get; set; }
        [FirestoreProperty]
        public string nombre { get; set; }
        [FirestoreProperty]
        public string pais { get; set; }
        [FirestoreProperty]
        public string provincia { get; set; }

    }
}
