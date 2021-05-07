using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    // That portal is passed to the PostManager here 
    // The PostManager inherets the interface which is just a method Execute()
    public class PostManager : IUserInterfaceManager
    {
        // These are the private variables noted with the underscore
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private string _connectionString;
        

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            // The private variables are now declared here and assigned a new value
            // Creating an instance of each here tying back to the parent file
            // Passing in again the portal to the Repositories
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            // That Interface Execute is defined here 
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
                    List();
                    return this;       
                case "2":
                    Add();
                    return this;
                case "3":
                    //Edit();
                    return this;
                case "4":
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
            // Here we create a new list instance of the class Post
            // Which is a container for the 
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Link : {post.Url}");
                Console.WriteLine($"Pushlished: {post.PublishDateTime}");
            }
        }


        private void Add()
        {
            // Creating a new object of post and storing items from its class
            Console.WriteLine("New Post");
            Post post = new Post();

            // A title
            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            // A URL
            Console.Write("URL: ");
            post.Url = Console.ReadLine();

            // A publishing date
            Console.Write("Published: ");
            post.PublishDateTime = Convert.ToDateTime(Console.ReadLine());

            // Need to implement a selection list for authors to store it as part of the object
            // What example code do I have?
            // The for loop from the Choose method in AuthorRepository
            // But me and Tommy made a new one
            Console.Write($"Please select an Author: \n");
            List<Author> authors = _authorRepository.GetAll();
            int i = 1;
            foreach (Author author in authors)

            {
                Console.WriteLine($"{i} {author}");
                i++;
            }
            Console.Write("> ");
            // Putting the user selection into object 'post'
            // But because the ReadLine reads input as a string, we convert it to number
            // Which corelates with a index inside the authors list
            post.Author = authors[Convert.ToInt32(Console.ReadLine())-1];
            

            // Same thing happens here in blog
            Console.Write($"Please select a Blog: \n");
            List<Blog> blogs = _blogRepository.GetAll();
            int j = 1;
            foreach (Blog blog in blogs)

            {
                Console.WriteLine($"{j}) {blog}");
                j++;
            }
            Console.Write("> ");
            post.Blog = blogs[Convert.ToInt32(Console.ReadLine()) - 1];
            


            // Using the dot operator we add all the properties of the object in 'post'
            // Then invoke the insert method on the post repository
            // Which is really just a class that communicates with a database

            // This all gets packaged up as 'post' and passed into the paramater for the Insert method
            _postRepository.Insert(post);
        }


        private Post Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an Post:";
            }

            Console.WriteLine(prompt);

            List<Post> posts = _postRepository.GetAll();

            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($" {i + 1}) {post.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return posts[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }



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

        private void Remove()
        {
            Post postToDelete = Choose("Which post would you like to remove?");
            if (postToDelete != null)
            {
                _postRepository.Delete(postToDelete.Id);
                Console.WriteLine();
            }
        }
    }
}
