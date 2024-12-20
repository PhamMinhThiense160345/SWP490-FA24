﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;

namespace Vegetarians_Assistant.Services.ModelView
{
    public class FeedbackView
    {
        public int FeedbackId { get; set; }

        public int DishId { get; set; }

        public int? UserId { get; set; }

        public int OrderId { get; set; }    

        public decimal? Rating { get; set; }

        public string? FeedbackContent { get; set; }

        public DateTime? FeedbackDate { get; set; }
    }
}
