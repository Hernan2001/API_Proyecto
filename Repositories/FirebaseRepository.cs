using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Proyecto_Api_Piwapp.Models;

namespace Proyecto_Api_Piwapp.Repositories
{
    public class FirebaseRepository
    {
        //creando repositorio general
        private readonly string CollectionName;
        public FirestoreDb firestoreDb;

        public FirebaseRepository(string CollectionName)
        {
            //Hace referencia a donde esta el archivo json
            //string filePath = "/Users/{Username}/Downloads/{file-name}.json";
            string filePath = "C:/Users/Nestor/Documents/Visual Studio 2022/Proyecto_Api_Piwapp/proyectpiwappr1-firebase-adminsdk-o88v0-3b1fab56ca.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            firestoreDb = FirestoreDb.Create("proyectpiwappr1");
            this.CollectionName = CollectionName;
        }

        public List<T> GetAll<T>() where T : FirebaseDocumentId
        {
            List<T> list = new();
            try
            {
                Query query = firestoreDb.Collection(CollectionName);
                QuerySnapshot querySnapshot = query.GetSnapshotAsync().GetAwaiter().GetResult();
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        T newItem = JsonConvert.DeserializeObject<T>(json);
                        newItem.Id = documentSnapshot.Id;
                        list.Add(newItem);
                    }
                }
            }
            catch
            {
            }
            return list;
        }


        public T Add<T>(T model) where T : FirebaseDocumentId
        {
            try
            {
                CollectionReference collectionReference = firestoreDb.Collection(CollectionName);
                DocumentReference newDocument = collectionReference.AddAsync(model).GetAwaiter().GetResult();
                model.Id = newDocument.Id;
                return model;
            }
            catch
            {
                return null;
            }
        }


        public T Get<T>(T model) where T : FirebaseDocumentId //FirebaseDocument: hace referencia en la Carpeta Model archivo FirebaseDocument
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                DocumentSnapshot snapshot = getDocument.GetSnapshotAsync().GetAwaiter().GetResult();
                if (snapshot.Exists)
                {
                    T usr = snapshot.ConvertTo<T>();
                    usr.Id = snapshot.Id;
                    return usr;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Update<T>(T model) where T : FirebaseDocumentId
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.SetAsync(model, SetOptions.MergeAll).GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete<T>(T model) where T : FirebaseDocumentId
        {
            try
            {
                DocumentReference getDocument = firestoreDb.Collection(CollectionName).Document(model.Id);
                getDocument.DeleteAsync().GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
