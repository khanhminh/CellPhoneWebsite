using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class ListCommentModel
    {
        public List<BinhLuan> comments { get; set; }
        public int count { get; set; }
        public int page { get; set; }
        public int totalPage
        {
            get
            {
                int total = count / Setting.CommentPerPage;
                if (total * Setting.CommentPerPage < count)
                {
                    total++;
                }

                return total;
            }
        }
    }
}