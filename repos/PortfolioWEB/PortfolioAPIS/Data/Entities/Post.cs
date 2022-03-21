﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWeb.Data
{
    public class Post: Entity, IDifferenceableEntity
    {
        public Post() { }
        public Post(int id)
        {
            Id = id;
            isEdited = false;
        }
        public Post(string topic, string content)
        {
            Topic = topic;
            Content = content;
        }
        public Post(string topic, string content,int userId)
        {
            Topic = topic ?? throw new ArgumentNullException(nameof(topic));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            UserId = userId;
            Comments= new List<Comment>();
            CreatedDate = DateTime.Now;
            isEdited = false;
        }

        public int Id { get; set; }

        public string Topic { get; set; }
        public string Content { get; set; }
        public bool isEdited { get; set ; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime editedDate { get; set; }
        public int Likes { get; set; }

        public IList<Comment> Comments { get; set; }

        public override bool Validate()
        {
            var IsValid = true;
            if (string.IsNullOrWhiteSpace(Topic)) IsValid = false;
            if (string.IsNullOrWhiteSpace(Content)) IsValid = false;
            return IsValid;
        }
    }
}
