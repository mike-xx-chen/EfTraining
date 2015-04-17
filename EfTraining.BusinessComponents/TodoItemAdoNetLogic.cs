﻿using MyCompany.EfTraining.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyCompany.EfTraining.BusinessComponents
{
    public class TodoItemAdoNetLogic : LogicBase
    {
        private const string CONNECTION_STRING =@"data source=.\two;initial catalog=Training;integrated security=True";//"server=.\two;integrated security=SSPI;database=Training";

        /// <summary>
        /// As the name implied, gets the first item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetFirst()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
               {
                   connection.Open();
                   var commandText = "SELECT TOP (1)" +
                                    "[Extent1].[ID] AS [ID]," +
                                    "[Extent1].[SORTING] AS [SORTING], " +
                                    "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                    "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                    "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," + 
                                    "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                    "[Extent1].[VERSION] AS [VERSION]" + 
                                    "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                    "ORDER BY [Extent1].[SORTING] ASC, [Extent1].[ID] ASC";
                   var command = new SqlCommand(commandText, connection);
                   var reader = command.ExecuteReader();
                   TodoItemEntity entity = null;
                   if(reader.Read())
                   {
                       entity = new TodoItemEntity();
                       entity.Id = (Int32)reader["ID"];
                       entity.Sorting = (Int32)reader["SORTING"];
                       entity.Description = (string)reader["DESCRIPTION"];
                       entity.IsDefault = (bool)reader["ISDEFAULT"];
                       entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                       if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                       {
                           entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                       }

                       entity.Version = (int)(reader["VERSION"]);
                   }

                    if(!reader.IsClosed)
                    {
                        reader.Close();
                    }

                   return entity;
               }
            }
            catch(Exception e)
            {

            }
            return null;
        }

        /// <summary>
        /// As the name implied, gets the last item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetLast()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var commandText = "SELECT TOP (1)" +
                                     "[Extent1].[ID] AS [ID]," +
                                     "[Extent1].[SORTING] AS [SORTING], " +
                                     "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                     "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                     "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," +
                                     "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                     "[Extent1].[VERSION] AS [VERSION]" +
                                     "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                     "ORDER BY [Extent1].[SORTING] DESC, [Extent1].[ID] DESC";
                    var command = new SqlCommand(commandText, connection);
                    var reader = command.ExecuteReader();
                    TodoItemEntity entity = null;
                    if (reader.Read())
                    {
                        entity = new TodoItemEntity();
                        entity.Id = (Int32)reader["ID"];
                        entity.Sorting = (Int32)reader["SORTING"];
                        entity.Description = (string)reader["DESCRIPTION"];
                        entity.IsDefault = (bool)reader["ISDEFAULT"];
                        entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                        if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                        {
                            entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                        }

                        entity.Version = (int)(reader["VERSION"]);
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }

                    return entity;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        /// <summary>
        /// Gets a item via a condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TodoItemEntity GetItemByKey(int key)
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var commandText = "SELECT TOP (1)" +
                                     "[Extent1].[ID] AS [ID]," +
                                     "[Extent1].[SORTING] AS [SORTING], " +
                                     "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                     "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                     "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," +
                                     "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                     "[Extent1].[VERSION] AS [VERSION]" +
                                     "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                     "WHERE [Extent1].[ID] = @ID";
                    var command = new SqlCommand(commandText, connection);
                    command.Parameters.AddWithValue("ID", key);
                    var reader = command.ExecuteReader();
                    TodoItemEntity entity = null;
                    if (reader.Read())
                    {
                        entity = new TodoItemEntity();
                        entity.Id = (Int32)reader["ID"];
                        entity.Sorting = (Int32)reader["SORTING"];
                        entity.Description = (string)reader["DESCRIPTION"];
                        entity.IsDefault = (bool)reader["ISDEFAULT"];
                        entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                        if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                        {
                            entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                        }

                        entity.Version = (int)(reader["VERSION"]);
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }

                    return entity;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        /// <summary>
        /// Gets a list of items via a certain condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        //public virtual IEnumerable<TodoItemEntity> GetItems(Expression<Func<TodoItemEntity, bool>> predicate)
        //{
        //    using (var context = new TContext())
        //    {
        //        return context.Set<TEntity>()
        //                      .Where(predicate)
        //                      .ToList();
        //    }
        //}

        /// <summary>
        /// As the name implied, gets all of items.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TodoItemEntity> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var commandText = "SELECT" +
                                     "[Extent1].[ID] AS [ID]," +
                                     "[Extent1].[SORTING] AS [SORTING], " +
                                     "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                     "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                     "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," +
                                     "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                     "[Extent1].[VERSION] AS [VERSION]" +
                                     "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                     "ORDER BY [Extent1].[SORTING] ASC, [Extent1].[ID] ASC";
                    var command = new SqlCommand(commandText, connection);
                    var reader = command.ExecuteReader();
                    List<TodoItemEntity> entities = new List<TodoItemEntity>();
                    while (reader.Read())
                    {
                        TodoItemEntity entity = new TodoItemEntity();
                        entity.Id = (Int32)reader["ID"];
                        entity.Sorting = (Int32)reader["SORTING"];
                        entity.Description = (string)reader["DESCRIPTION"];
                        entity.IsDefault = (bool)reader["ISDEFAULT"];
                        entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                        if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                        {
                            entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                        }

                        entity.Version = (int)(reader["VERSION"]);
                        entities.Add(entity);
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }

                    return entities;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        /// <summary>
        /// AS the name implied, gets the default item.
        /// </summary>
        /// <returns></returns>
        public virtual TodoItemEntity GetDefault()
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var commandText = "SELECT TOP (1)" +
                                     "[Extent1].[ID] AS [ID]," +
                                     "[Extent1].[SORTING] AS [SORTING], " +
                                     "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                     "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                     "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," +
                                     "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                     "[Extent1].[VERSION] AS [VERSION]" +
                                     "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                     "ORDER BY [Extent1].[ISDEFAULT] DESC, [Extent1].[SORTING] ASC, [Extent1].[ID] ASC";
                    var command = new SqlCommand(commandText, connection);
                    var reader = command.ExecuteReader();
                    TodoItemEntity entity = null;
                    if (reader.Read())
                    {
                        entity = new TodoItemEntity();
                        entity.Id = (Int32)reader["ID"];
                        entity.Sorting = (Int32)reader["SORTING"];
                        entity.Description = (string)reader["DESCRIPTION"];
                        entity.IsDefault = (bool)reader["ISDEFAULT"];
                        entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                        if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                        {
                            entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                        }

                        entity.Version = (int)(reader["VERSION"]);
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }

                    return entity;
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }

        /// <summary>
        /// Saves all incoming entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual bool Save(IEnumerable<TodoItemEntity> entities)
        {
            bool retVal =  false;
            int affectedRows = 0;

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                    {
                        connection.Open();
    
                        foreach (var item in entities)
                        {
                            if (item.Version != 0)
                            {
                                item.Version++;
                                item.UpdatedDate = DateTime.UtcNow;

                                var commandText = "UPDATE [dbo].[BAS_TODOITEM] SET [SORTING]=@Sorting, [DESCRIPTION]=@Description, [ISDEFAULT]=@IsDefault, [UPDATEDDATE] = @UpdatedDate, [VERSION] = @Version WHERE [ID]=@Id";
                                var command = new SqlCommand(commandText, connection);
                                command.Parameters.AddWithValue("@Id", item.Id);
                                command.Parameters.AddWithValue("@Sorting", item.Sorting);
                                command.Parameters.AddWithValue("@Description", item.Description);
                                command.Parameters.AddWithValue("@IsDefault", item.IsDefault);
                                command.Parameters.AddWithValue("@UpdatedDate", item.UpdatedDate);
                                command.Parameters.AddWithValue("@Version", item.Version);
                                affectedRows += command.ExecuteNonQuery();
                            }
                            else
                            {
                                item.Version++;
                                item.CreatedDate = DateTime.UtcNow;
                                var commandText = "INSERT INTO [dbo].[BAS_TODOITEM] ([ID],[SORTING],[DESCRIPTION],[ISDEFAULT],[CREATEDDATE],[UPDATEDDATE],[VERSION]) VALUES(@Id,@Sorting,@Description, @IsDefault, @CreatedDate, @UpdatedDate, @Version)";
                                var command = new SqlCommand(commandText, connection);
                                command.Parameters.AddWithValue("@Id", item.Id);
                                command.Parameters.AddWithValue("@Sorting", item.Sorting);
                                command.Parameters.AddWithValue("@Description", item.Description);
                                command.Parameters.AddWithValue("@IsDefault", item.IsDefault);
                                command.Parameters.AddWithValue("@CreatedDate", item.CreatedDate);
                                command.Parameters.AddWithValue("@UpdatedDate", item.UpdatedDate);
                                command.Parameters.AddWithValue("@Version", item.Version);
                                affectedRows += command.ExecuteNonQuery();
                            }
                        }
                    }
                    // Then mark complete
                    scope.Complete();
                    retVal = affectedRows > 0;
                }
            }
            catch(Exception e)
            {

            }

            return retVal;
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Save(TodoItemEntity entity)
        {
            return Save(new List<TodoItemEntity>() { entity });
        }

        /// <summary>
        /// Deletes the incoming items.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Delete(IEnumerable<TodoItemEntity> entities)
        {
            Delete(entities.Select(e => e.Id).ToList());
        }

        /// <summary>
        /// Deletes the incoming item.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TodoItemEntity entity)
        {
            Delete(entity.Id);
        }

        /// <summary>
        /// Deletes the item by id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int id)
        {
            Delete(new List<int>() { id });
        }

        /// <summary>
        /// Deletes a list of items by id.
        /// </summary>
        /// <param name="ids"></param>
        public virtual void Delete(IEnumerable<int> ids)
        {
            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    StringBuilder commandText = new StringBuilder();
                    commandText.Append("DELETE [dbo].[BAS_TODOITEM] WHERE [ID] IN (");
                    for (int i = 0; i < ids.Count(); i++)
                    {
                        if (i > 0)
                        {
                            commandText.Append(',');
                        }

                        commandText.Append(ids.ElementAt(i));
                    }
                    commandText.Append(")");

                    var command = new SqlCommand(commandText.ToString(), connection);
                    var affectedRows = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Based on multiple keyword search
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public virtual IEnumerable<TodoItemEntity> Search(string searchText)
        {
            var charSeparators = new Char[]{' '};
            var keywords = searchText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder whereClause = new StringBuilder();
            whereClause.Append(" WHERE ");
            for (int i = 0; i < keywords.Count(); i++)
            {
                if (i > 0)
                {
                    whereClause.Append(" OR ");
                }

                whereClause.Append("[Extent1].[DESCRIPTION] LIKE ");
                whereClause.Append(string.Format("@P{0}", i));
            }

            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    var commandText = "SELECT " +
                                     "[Extent1].[ID] AS [ID]," +
                                     "[Extent1].[SORTING] AS [SORTING], " +
                                     "[Extent1].[DESCRIPTION] AS [DESCRIPTION]," +
                                     "[Extent1].[ISDEFAULT] AS [ISDEFAULT], " +
                                     "[Extent1].[CREATEDDATE] AS [CREATEDDATE]," +
                                     "[Extent1].[UPDATEDDATE] AS [UPDATEDDATE], " +
                                     "[Extent1].[VERSION] AS [VERSION]" +
                                     "FROM [dbo].[BAS_TODOITEM] AS [Extent1]" +
                                      whereClause.ToString() +
                                     " ORDER BY [Extent1].[SORTING] ASC, [Extent1].[ID] ASC";
                    var command = new SqlCommand(commandText, connection);
                    for (int i = 0; i < keywords.Count(); i++)
                    {
                        command.Parameters.AddWithValue(string.Format("@P{0}", i), "%"+keywords[i]+"%");
                    }

                    var reader = command.ExecuteReader();
                    List<TodoItemEntity> entities = new List<TodoItemEntity>();
                    while (reader.Read())
                    {
                        TodoItemEntity entity = new TodoItemEntity();
                        entity.Id = (Int32)reader["ID"];
                        entity.Sorting = (Int32)reader["SORTING"];
                        entity.Description = (string)reader["DESCRIPTION"];
                        entity.IsDefault = (bool)reader["ISDEFAULT"];
                        entity.CreatedDate = (DateTime)reader["CREATEDDATE"];
                        if (!reader.IsDBNull(reader.GetOrdinal("UPDATEDDATE")))
                        {
                            entity.UpdatedDate = (DateTime?)reader["UPDATEDDATE"];
                        }

                        entity.Version = (int)(reader["VERSION"]);
                        entities.Add(entity);
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }

                    return entities;
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="isDefault"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        public TodoItemEntity Create(string description, bool isDefault, int sorting = 0)
        {
            ISequenceManager manager = SequenceManagerFactory.Create<TrainingDbContext>();

            return new TodoItemEntity()
            {
                Id = manager.GetNext<TodoItemEntity>(),
                Description = description,
                IsDefault = isDefault,
                Sorting = sorting,
            };
        }
    }
}
