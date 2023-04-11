using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASPDotNetIntro.Pages
{
    public class IndexBookModel : PageModel
    {
        public List<Books1> booksList;
        public void OnGet()
        {
            try
            {
                booksList = new List<Books1>();
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8D7OITT;Initial Catalog=LMS_DB;Integrated Security=True;Encrypt=False;");
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT BOOK_CODE,BOOK_TITLE,AUTHOR,PUBLICATION,PRICE FROM LMS_BOOK_DETAILS;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Books1 book = new Books1();

                    book.BookCode = (string)reader["BOOK_CODE"];
                    book.BookTitle = (string)reader["BOOK_TITLE"];
                    book.Author = (string)reader["AUTHOR"];
                    book.Publication = (string)reader["PUBLICATION"];
                    book.Price = (int)reader["PRICE"];

                    booksList.Add(book);
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }

    public class Books1
    {
        public string BookCode { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public int Price { get; set; }
    }
}