using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWeb.Data
{
    public class Comment: Entity, IDifferenceableEntity
    {
        public Comment()
        {
                
        }
        public Comment(int iD)
        {
            ID = iD;
            CreatedDate = DateTime.Now;
            isEdited = false;

        }
        public Comment(string title,string text)
        {
            Title = title;
            Text = text;
        }
        public Comment(string title, string text, int postID, int authorID)
        {
            Title = title;
            Text = text;
            PostID = postID;
            UserID = authorID;
            Likes = 0;
            CreatedDate = DateTime.Now;
            isEdited = false;   

        }

        public int ID { get; set; }
        public string Title { get; set; }
        public bool isEdited { get; set; }
        public string Text { get; set; }
        [ForeignKey("PostID")]
        public int? PostID { get; set; }
        [ForeignKey("UserID")]
        public int? UserID { get; set; }

        public int Likes { get; set; }
        public DateTime editedDate { get; set; }

        public override bool Validate()
        {
            var IsValid = true;
            if (string.IsNullOrWhiteSpace(Title)) IsValid = false;
            if (string.IsNullOrWhiteSpace(Text)) IsValid = false;
            return IsValid;
        }



    }
}
