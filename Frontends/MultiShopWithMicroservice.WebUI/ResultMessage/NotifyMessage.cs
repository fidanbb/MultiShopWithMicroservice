namespace MultiShopWithMicroservice.WebUI.ResultMessage
{
    public static class NotifyMessage
    {
        public static class ResultTitle
        {
            public static string Add(string title)
            {
                return $"{title} added successfully";
            }

            public static string Update(string title)
            {
                return $"{title} updated successfully";
            }

            public static string Delete(string title)
            {
                return $"{title} deleted successfully";
            }

            public static string Warning(string title)
            {
                return $"{title} needs to be checked";
            }

            public static string UndoDelete(string title)
            {
                return $"{title} has been successfully retrieved";
            }

            public static string Info()
            {
                return $"Loading";
            }
        }
    }
}

