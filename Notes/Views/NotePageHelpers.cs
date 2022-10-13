namespace Notes.Views
{
    internal static class NotePageHelpers
    {
        private static object itemId;

        public static object GetItemId()
        {
            return itemId;
        }

        internal static object ItemId() => throw new NotImplementedException();

        internal static void SetItemId(object value)
        {
            itemId = value;
        }
    }
}