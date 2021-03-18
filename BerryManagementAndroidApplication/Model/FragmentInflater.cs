using Android.App;
using Android.Content;
using Android.Transitions;
using Android.Views;

namespace BerryManagementAndroidApplication.Model
{
    public static class FragmentInflater
    {
        public static void InflateFragment(FragmentManager fm,Fragment fragment)
        {
            fragment.EnterTransition = new Slide(GravityFlags.Left);
            fragment.ExitTransition = new Slide(GravityFlags.Right);
            FragmentTransaction ft = fm.BeginTransaction();
            ft.Replace(Resource.Id.content_frame, fragment);
            ft.AddToBackStack(null);
            ft.Commit();
        }
    }
}