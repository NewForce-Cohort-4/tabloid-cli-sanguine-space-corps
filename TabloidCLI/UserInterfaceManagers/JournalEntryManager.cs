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

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Entry Menu");
            Console.WriteLine(" 1) List Entries");
            Console.WriteLine(" 2) Entry Details");
            Console.WriteLine(" 3) Add Entry");
            Console.WriteLine(" 4) Edit Entry");
            Console.WriteLine(" 5) Remove Entry");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    JournalEntry journalEntry = Choose();
                    if (journalEntry == null)
                    {
                        return this;
                    }
                    else
                    {
                        return new JournalDetailManager(this, _connectionString, journalEntry.Id);
                    }
                case "3":
                    Add();
                    return this;
                case "4":
                    Edit();
                    return this;
                case "5":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            List<JournalEntry> entries = _journalentryRepository.GetAll();
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        private JournalEntry Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an Entry:";
            }

            Console.WriteLine(prompt);

            List<JournalEntry> entries = _journalentryRepository.GetAll();

            for (int i = 0; i < entries.Count; i++)
            {
                JournalEntry entry = entries[i];
                Console.WriteLine($" {i + 1}) {entry.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return entries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Entry");
            JournalEntry entry = new JournalEntry();

            Console.Write("Title: ");
            entry.Title = Console.ReadLine();

            Console.Write("Entry: ");
            entry.Content = Console.ReadLine();

            Console.Write("Date: ");
            entry.CreateDateTime = Convert.ToDateTime(Console.ReadLine());


            _journalentryRepository.Insert(entry);
        }

        private void Edit()
        {
            JournalEntry entryToEdit = Choose("Which entry would you like to edit?");
            if (entryToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("New title (blank to leave unchanged: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                entryToEdit.Title = title;
            }
            Console.Write("New entry (blank to leave unchanged: ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                entryToEdit.Content = entry;
            }
            Console.Write("New Date: (blank to leave unchanged: ");
            string UnparsedDate = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(UnparsedDate))
            {
                entryToEdit.CreateDateTime = Convert.ToDateTime(UnparsedDate);
            }

            _journalentryRepository.Update(entryToEdit);
        }

        private void Remove()
        {
            JournalEntry entryToDelete = Choose("Which author would you like to remove?");
            if (entryToDelete != null)
            {
                _journalentryRepository.Delete(entryToDelete.Id);
            }
        }
    }
}
