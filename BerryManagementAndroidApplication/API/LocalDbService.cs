using System;
using System.Threading.Tasks;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.StructureService;

namespace BerryManagementAndroidApplication.API
{
    public static class LocalDbService<T> where T: new()
    {
      
        private static SQLiteClient<T> _instance;

        public static SQLiteClient<T> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLiteClient<T>();
                return _instance;
            }
        }

    }
}
