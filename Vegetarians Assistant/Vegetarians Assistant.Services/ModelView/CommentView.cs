﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetarians_Assistant.Services.ModelView
{
    public class CommentView
    {
        public int CommentId { get; set; }

        public int ArticleId { get; set; }

        public int UserId { get; set; }

        public string? Content { get; set; }

        public DateTime? PostDate { get; set; }

        public string? UserName { get; set; }
    }
}