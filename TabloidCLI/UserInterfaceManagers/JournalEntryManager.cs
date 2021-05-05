using System;
using System.Collections.Generic;
using System.Text;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    class JournalEntryManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalEntryRepository _journalentryRepository;
        private string _connectionString;

        public JournalEntryManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalentryRepository = new JournalEntryRepository(connectionString);
            _connectionString = connectionString;
        }

        public  IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Entry Menu");
            Console.WriteLine(" 1) List Entries");
            Console.WriteLine(" 2) Entry Details");
            Console.WriteLine(" 3) Add Entry");
            Console.WriteLine(" 4) Edit Entry");
            Console.WriteLine(" 5) Remove Entry");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            //string choice = Console.ReadLine();
            //switch (choice)
            //{
            //    case "1":
            //        List();
            //        return this;
            //    case "2":
            //        JournalEntry journalEntry = Choose();
            //        if (journalEntry == null)
            //        {
            //            return this;
            //        }
            //        else
            //        {
            //            return new JournalDetailManager(this, _connectionString, journalEntry.Id);
            //        }
            //    case "3":
            //        Add();
            //        return this;
            //    case "4":
            //        Edit();
            //        return this;
            //    case "5":
            //        Remove();
            //        return this;
            //    case "0":
            //        return _parentUI;
            //    default:
            //        Console.WriteLine("Invalid Selection");
            //        return this;
            //}
            return null;
        }
        
        
    }
}
