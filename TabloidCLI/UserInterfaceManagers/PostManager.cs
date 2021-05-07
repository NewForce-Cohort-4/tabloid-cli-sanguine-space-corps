using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private string _connectionString;
        

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Post Menu");
            Console.WriteLine(" 1) List Posts");
            Console.WriteLine(" 2) Add Post");
            Console.WriteLine(" 3) Edit Post");
            Console.WriteLine(" 4) Remove Posts");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //List();
                    return this;       
                case "2":
                    Add();
                    return this;
                case "3":
                    //Edit();
                    return this;
                case "4":
                    //Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        //private void List()
        //{
        //    List<Post> posts = _postRepository.GetAll();
        //    foreach (Post post in posts)
        //    {
        //        Console.WriteLine(post);
        //    }
        //}


        private void Add()
        {
            Console.WriteLine("New Author");
            Post post = new Post();

            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            Console.Write("URL: ");
            post.Url = Console.ReadLine();

            Console.Write("Published: ");
            post.PublishDateTime = Convert.ToDateTime(Console.ReadLine());

            // Need to implement a selection list for authors
            // What example code do I have?
            Console.Write("Please select an Author: ");
            List<Author> authors = _authorRepository.GetAll();
            int i = 1;
            foreach (Author author in authors)

            {
                Console.WriteLine($"{i} {author}");
                i++;
            }
            Console.Write("> ");
            post.Author = authors[Convert.ToInt32(Console.ReadLine())-1];
            


            // Remember that I still need to update the insert method inside PostRepository
            //Console.Write("Blog: ");
            //List<Blog> blogs = _blogRepository.GetAll();
            //for (int j = 0; j < blogs.Count; j++)
            //{
            //    Blog blog = blogs[j];
            //    Console.WriteLine($" {j + 1}) {blog}");
            //}
            //Console.Write("> ");

            List<Blog> blogs = _blogRepository.GetAll();
            int j = 1;
            foreach (Blog blog in blogs)

            {
                Console.WriteLine($"{j}) {blog}");
                j++;
            }
            
            post.Blog = blogs[Convert.ToInt32(Console.ReadLine()) - 1];
            Console.Write("> ");



            _postRepository.Insert(post);
        }


        //private Author ChooseAuthor(string prompt = null)
        //{
        //    if (prompt == null)
        //    {
        //        prompt = "Please choose an Author:";
        //    }

        //    Console.WriteLine(prompt);

        //    List<Author> authors = _authorRepository.GetAll();

        //    for (int i = 0; i < authors.Count; i++)
        //    {
        //        Author author = authors[i];
        //        Console.WriteLine($" {i + 1}) {author.FullName}");
        //    }
        //    Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
        //        int choice = int.Parse(input);
        //        return authors[choice - 1];
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Invalid Selection");
        //        return null;
        //    }
        //}

        //private Blog ChooseBlog(string prompt = null)
        //{
        //    if (prompt == null)
        //    {
        //        prompt = "Please choose a Blog:";
        //    }

        //    Console.WriteLine(prompt);

        //    List<Blog> blogs = _blogRepository.GetAll();

        //    for (int i = 0; i < blogs.Count; i++)
        //    {
        //        Blog blog = blogs[i];
        //        Console.WriteLine($" {i + 1}) {blog.Title}");
        //    }
        //    Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
        //        int choice = int.Parse(input);
        //        return blogs[choice - 1];
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Invalid Selection");
        //        return null;
        //    }
        //}

        //private void Edit()
        //{
        //    Author authorToEdit = Choose("Which author would you like to edit?");
        //    if (authorToEdit == null)
        //    {
        //        return;
        //    }

        //    Console.WriteLine();
        //    Console.Write("New first name (blank to leave unchanged: ");
        //    string firstName = Console.ReadLine();
        //    if (!string.IsNullOrWhiteSpace(firstName))
        //    {
        //        authorToEdit.FirstName = firstName;
        //    }
        //    Console.Write("New last name (blank to leave unchanged: ");
        //    string lastName = Console.ReadLine();
        //    if (!string.IsNullOrWhiteSpace(lastName))
        //    {
        //        authorToEdit.LastName = lastName;
        //    }
        //    Console.Write("New bio (blank to leave unchanged: ");
        //    string bio = Console.ReadLine();
        //    if (!string.IsNullOrWhiteSpace(bio))
        //    {
        //        authorToEdit.Bio = bio;
        //    }

        //    _authorRepository.Update(authorToEdit);
        //}

        //private void Remove()
        //{
        //    Author authorToDelete = Choose("Which author would you like to remove?");
        //    if (authorToDelete != null)
        //    {
        //        _authorRepository.Delete(authorToDelete.Id);
        //    }
        //}
    }
}
