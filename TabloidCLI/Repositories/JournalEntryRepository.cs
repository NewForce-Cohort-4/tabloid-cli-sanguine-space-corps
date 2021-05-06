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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public JournalEntry Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<JournalEntry> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                               Content
                                               CreateDateTime
                                            From Journal";

                    List<JournalEntry> entries = new List<JournalEntry>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        JournalEntry entry = new JournalEntry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
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

        public void Insert(JournalEntry entry)
        {
            throw new NotImplementedException();
        }

        public void Update(JournalEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
