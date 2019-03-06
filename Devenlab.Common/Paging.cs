namespace Devenlab.Common
{
    public class Paging
    {
        public Paging()
        {
            Start = 0;
            Limit = DEFAULT_PAGING;
            // TODO CONFIGURABLE
            Direction = DEFAULT_SORT_DIRECTION;
            SortColumn = DEFAULT_SORT_COLUMN;
        }

        public static Paging Instance()
        {
            return new Paging();
        }

        public const string DEFAULT_SORT_COLUMN = "id";
        public const string DEFAULT_SORT_DIRECTION = "ASC";
        public const int DEFAULT_PAGING = 1;
        public static Paging Instance(int start)
        {
            return new Paging
                {
                    Start = start,
                    Limit = DEFAULT_PAGING,
                    // TODO CONFIGURABLE
                    Direction = DEFAULT_SORT_DIRECTION,
                    SortColumn = DEFAULT_SORT_COLUMN
                };
        }

        public static Paging Instance(int start, int limit)
        {
            return new Paging
                {
                    Start = start*limit,
                    Limit = limit,
                    // TODO CONFIGURABLE
                    Direction = DEFAULT_SORT_DIRECTION,
                    SortColumn = DEFAULT_SORT_COLUMN
                };
        }

        public static Paging Instance(int start, int limit, string direction)
        {
            return new Paging
                {
                    Start = start,
                    Limit = limit,
                    // TODO CONFIGURABLE
                    Direction = GetValue(direction, DEFAULT_SORT_DIRECTION),
                    SortColumn = DEFAULT_SORT_COLUMN
                };
        }

        public static Paging Instance(int start, int limit, string direction, string sortColumn)
        {
            return new Paging
                {
                    Start = start,
                    Limit = limit,
                    // TODO CONFIGURABLE
                    Direction = GetValue(direction, DEFAULT_SORT_DIRECTION),
                    SortColumn = GetValue(sortColumn, DEFAULT_SORT_COLUMN)
                };
        }

        private static string GetValue(string value, string defaultvalue)
        {
            switch (value)
            {
                case "RecordStatus":
                    return "RowStatus";
                case "":
                    return defaultvalue;
                case null:
                    return defaultvalue;
                default:
                    return value;
            }
            //return string.IsNullOrEmpty(value) ? defaultvalue : value;
        }

        public int Start { get; set; }
        public int Limit { get; set; }
        public string Direction { get; set; }
        public string SortColumn { get; set; }
    }
}
