/// <summary>
/// რედაქტირების ფორმების მუშაობის რეჯიმები
/// </summary>
namespace BerryManagementApplication.Enums
{
    public enum DataChangeType
    {
        Insert,
        Update,
        Delete
    }

    public enum ActionMode
    {
        /// <summary>
        /// დამუშავებული მონაცემების დაბრუნება
        /// </summary>
        ReturnDataOnly = 1,
        /// <summary>
        /// დამუშავებული მონაცემების გადაწერა ბაზაში და მათი დაბრუნება
        /// </summary>
        WriteAndReturnData = 2
    }

}
