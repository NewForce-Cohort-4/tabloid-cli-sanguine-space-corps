using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.Repositories
{
    class JournalEntryRepository : DatabaseConnector, IRepository<JournalEntry>
    {
        public JournalEntryRepository(string connectionString) : base(connectionString) { }

        public List<JournalEntry> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                               Content,
                                               CreateDateTime
                                            From Journal";

                    List<JournalEntry> entries = new List<JournalEntry>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        JournalEntry entry = new JournalEntry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                        };
                        
                        entries.Add(entry);
                    }

                    reader.Close();

                    return entries;
                }
            }
        }

        public JournalEntry Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT j.Id AS JournalId,
                                               j.Title,
                                               j.Content,
                                               j.CreateDatetime,
                                               t.Id AS TagId,
                                               t.Name
                                          FROM Journal j 
                                               LEFT JOIN JournalTag jt on j.Id = jt.JournalId
                                               LEFT JOIN Tag t on t.Id = jt.TagId
                                         WHERE j.id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    JournalEntry entry = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (entry == null)
                        {
                            entry = new JournalEntry()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("JournalId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),
                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            entry.Tags.Add(new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            });
                        }
                    }

                    reader.Close();

                    return entry;
                }
            }
        }

        public void Insert(JournalEntry entry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Journal (Title, Content, CreateDateTime )
                                                     VALUES (@Title, @Content, @CreateDateTime)";
                    cmd.Parameters.AddWithValue("@Title", entry.Title);
                    cmd.Parameters.AddWithValue("@Content", entry.Content);
                    cmd.Parameters.AddWithValue("@CreateDateTime", entry.CreateDateTime);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(JournalEntry entry)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Journal 
                                           SET Title = @title,
                                               Content = @content,
                                               CreateDateTime = @createdatetime
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@title", entry.Title);
                    cmd.Parameters.AddWithValue("@content", entry.Content);
                    cmd.Parameters.AddWithValue("@createdatetime", entry.CreateDateTime);
                    cmd.Parameters.AddWithValue("@id", entry.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Journal WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertTag(JournalEntry entry, Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO JournalTag (JournalId, TagId)
                                                       VALUES (@journalId, @tagId)";
                    cmd.Parameters.AddWithValue("@journalId", entry.Id);
                    cmd.Parameters.AddWithValue("@tagId", tag.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void DeleteTag(int authorId, int tagId)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"DELETE FROM AuthorTAg 
        //                                 WHERE AuthorId = @authorid AND 
        //                                       TagId = @tagId";
        //            cmd.Parameters.AddWithValue("@authorId", authorId);
        //            cmd.Parameters.AddWithValue("@tagId", tagId);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
