using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.ViewModels
{
    public class UserReviewViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
    }
}
