using BookStore.Business.ViewModels.BookViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.ViewModels.BookViewModels
{
    public class BookVM : BookAddVM
    {
        public int Id { get; set; }
    }
}
