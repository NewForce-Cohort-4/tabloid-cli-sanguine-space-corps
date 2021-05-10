using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    class TagDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;
        private int _tagId;

        public TagDetailManager(IUserInterfaceManager parentUI, string connectionString, int tagId)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
            _tagId = tagId;
        }

        public IUserInterfaceManager Execute()
        {
            Tag tag = _tagRepository.Get(_tagId);
            Console.WriteLine($"{tag.Name} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View();
                    return this;

                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void View()
        {
            Tag tag = _tagRepository.Get(_tagId);
            Console.WriteLine($"Name: {tag.Name}");

        }
    }
}
