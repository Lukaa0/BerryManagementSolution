using System.Threading.Tasks;
using Android.Content;
using Android.Media;

namespace BerryManagementAndroidApplication.API
{
    public static class Sounder
    {
        public static void ErrorSound(Context context)
        {
            var player = MediaPlayer.Create(context, Resource.Raw.error_sound);
            player.Start();
        }

        public static async Task ErrorSoundAsync(Context context)
        {
            await Task.Run(() => ErrorSound(context));
        }

        public static void NotificationSound(Context context)
        {
            var player = MediaPlayer.Create(context, Resource.Raw.Notification);
            player.Start();
        }

        public static async Task NotificationSoundAsync(Context context)
        {
            await Task.Run(() => NotificationSound(context));
        }
    }
}