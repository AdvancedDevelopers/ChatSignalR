namespace Codefirst_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Models : DbContext
    {
        // Your context has been configured to use a 'Models' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Codefirst_Models.Models' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Models' 
        // connection string in the application configuration file.
        public Models()
            : base("name=ChatExample_db")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<ChatSession> ChatSessions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }

    public class ChatSession
    {
        public int Id { get; set; }
        public DateTime StartedAt { get; set; }
        public virtual List<Message> Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        [MaxLength(255,ErrorMessage ="Please Insert a Body in 255 Letters")]
        [Display(Name = "Message")]
        public string Body { get; set; }
        [EmailAddress]
        [Display(Name ="Email")]
        [MaxLength(150,ErrorMessage ="Please Add From in 150 Characters")]
        public string From { get; set; }
        [Display(Name = "Sent At")]
        public DateTime SentAt { get; set; }
        [Display(Name = "Session")]
        public int ChatSessionId { get; set; }
    }
}