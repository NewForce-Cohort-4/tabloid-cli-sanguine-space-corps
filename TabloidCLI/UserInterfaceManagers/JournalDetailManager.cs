using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    class JournalDetailManager : IUserInterfaceManager
    { 
        
            private IUserInterfaceManager _parentUI;
            private JournalEntryRepository _journalentryRepository;
            private PostRepository _postRepository;
            private TagRepository _tagRepository;
            private int _journalentryId;

            public JournalDetailManager(IUserInterfaceManager parentUI, string connectionString, int journalentryId)
            {
                _parentUI = parentUI;
                _journalentryRepository = new JournalEntryRepository(connectionString);
                _postRepository = new PostRepository(connectionString);
                _tagRepository = new TagRepository(connectionString);
                _journalentryId = journalentryId;
            }

        public IUserInterfaceManager Execute()
        {
            JournalEntry journalEntry = _journalentryRepository.Get(_journalentryId);
            Console.WriteLine("Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) View Blog Posts");
            Console.WriteLine(" 3) Add Tag");
            Console.WriteLine(" 4) Remove Tag");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                   // View();
                    return this;
                case "2":
                    //ViewBlogPosts();
                    return this;
                case "3":
                    //AddTag();
                    return this;
                case "4":
                   // RemoveTag();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
