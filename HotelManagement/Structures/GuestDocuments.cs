namespace HotelManagement.Structures
{
    public class GuestDocuments
    {
        public bool IsChild { get; set; }
        public string Document { get; set; }
        public GuestDocuments() { }
        public GuestDocuments(string document)
        {
            IsChild = document.Length == 10 ? false : true;
            Document = document;
        }
        public GuestDocuments(bool isChild, string document)
        {
            IsChild = isChild;
            Document = document;
        }
    }
}
