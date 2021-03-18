using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Math = System.Math;

namespace BerryManagementAndroidApplication.Model
{
    public class GridAutoFitLayoutManager : GridLayoutManager
    {
        private int mColumnWidth;
        private bool mColumnWidthChanged = true;
        private bool mWidthChanged = true;
        private int mWidth;
        private static int sColumnWidth = 200; // assume cell width of 200dp

        public GridAutoFitLayoutManager(Context context, int columnWidth) : base(context, 1)
        {
            /* Initially set spanCount to 1, will be changed automatically later. */
            setColumnWidth(checkedColumnWidth(context, columnWidth));
        }

        public GridAutoFitLayoutManager(Context context, int columnWidth, int orientation, bool reverseLayout) : base(
            context, 1, orientation, reverseLayout)
        {
            /* Initially set spanCount to 1, will be changed automatically later. */
            setColumnWidth(checkedColumnWidth(context, columnWidth));
        }

        private int checkedColumnWidth(Context context, int columnWidth)
        {
            if (columnWidth <= 0)
            {
                columnWidth = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, sColumnWidth,
                    context.Resources.DisplayMetrics);
            }
            else
            {
                columnWidth = (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, columnWidth,
                    context.Resources.DisplayMetrics);
            }

            return columnWidth;
        }

        private void setColumnWidth(int newColumnWidth)
        {
            if (newColumnWidth > 0 && newColumnWidth != mColumnWidth)
            {
                mColumnWidth = newColumnWidth;
                mColumnWidthChanged = true;
            }
        }

        public override void OnLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state)
        {
            int width = Width;
            int height = Height;

            if (width != mWidth)
            {
                mWidthChanged = true;
                mWidth = width;
            }

            if (mColumnWidthChanged && mColumnWidth > 0 && width > 0 && height > 0
                || mWidthChanged)
            {
                int totalSpace;
                if (Orientation == Vertical)
                {
                    totalSpace = width - PaddingRight - PaddingLeft;
                }
                else
                {
                    totalSpace = height - PaddingTop - PaddingBottom;
                }

                int spanCount = Math.Max(1, totalSpace / mColumnWidth);
                SpanCount = spanCount;
                mColumnWidthChanged = false;
                mWidthChanged = false;
            }

            base.OnLayoutChildren(recycler, state);
        }
    }
}