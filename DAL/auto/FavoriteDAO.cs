using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using MvcApplication1.Model;
using MvcApplication1.Utility;
namespace MvcApplication1.DAO
{
    public partial class FavoriteDAO
    {
        #region �����ݿ������һ����¼ +bool Insert(Favorite model)
        ///<summary>
        ///�����ݿ������һ����¼
        ///</summary>
        ///<param name="model">Ҫ��ӵ�ʵ��</param>
        public bool Insert(Favorite model)
        {
            const string sql = @"INSERT INTO [dbo].[Favorite] (favorites_id,type,favorites_title,favorites_info,image) VALUES (@favorites_id,@type,@favorites_title,@favorites_info,@image)";
            int res = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@favorites_id", model.favorites_id.ToDBValue()), new SqlParameter("@type", model.type.ToDBValue()), new SqlParameter("@favorites_title", model.favorites_title.ToDBValue()), new SqlParameter("@favorites_info", model.favorites_info.ToDBValue()), new SqlParameter("@image", model.image.ToDBValue()));
            return res > 0;
        }

        /// <summary>
        /// ɾ�����м�¼
        /// </summary>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool DeleteAll()
        {
            const string sql = "truncate table [dbo].[Favorite]";
            //const string sql = "DELETE FROM [dbo].[Favorite]";
            return SqlHelper.ExecuteNonQuery(sql, null) == -1;
        }
        #endregion
        #region ɾ��һ����¼ +bool Delete(int favorites_id)
        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="favorites_id">����</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool Delete(long favorites_id)
        {
            const string sql = "DELETE FROM [dbo].[Favorite] WHERE [favorites_id] = @favorites_id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@favorites_id", favorites_id)) > 0;
        }
        #endregion
        #region ��������ID����һ����¼ +bool Update(Favorite model)
        /// <summary>
        /// ������������һ����¼
        /// </summary>
        /// <param name="model">���º��ʵ��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool Update(Favorite model)
        {
            const string sql = @"UPDATE [dbo].[Favorite] SET  type=@type,favorites_title=@favorites_title,favorites_info=@favorites_info,image=@image  WHERE [favorites_id] = @favorites_id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@favorites_id", model.favorites_id.ToDBValue()), new SqlParameter("@type", model.type.ToDBValue()), new SqlParameter("@favorites_title", model.favorites_title.ToDBValue()), new SqlParameter("@favorites_info", model.favorites_info.ToDBValue()), new SqlParameter("@image", model.image.ToDBValue())) > 0;
        }
        #endregion
        #region ��ѯ���� +int QueryCount(object wheres)
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="wheres">��ѯ����</param>
        /// <returns>����</returns>
        public int QueryCount(object wheres)
        {
            List<SqlParameter> list = null;
            string str = wheres.parseWheres(out list);
            str = str == "" ? str : "where " + str;
            string sql = "SELECT COUNT(1) from Favorite " + str; var res = SqlHelper.ExecuteScalar(sql, list.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
        #region ��ѯ����ģ��ʵ�� +Favorite QuerySingleById(long favorites_id)
        /// <summary>
        /// ��ѯ����ģ��ʵ��
        /// </summary>
        /// <param name="id">favorites_id</param>);
        /// <returns>ʵ��</returns>);
        public Favorite QuerySingleById(long favorites_id)
        {
            const string sql = "SELECT TOP 1 favorites_id,type,favorites_title,favorites_info,image from Favorite WHERE [favorites_id] = @favorites_id";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@favorites_id", favorites_id)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    Favorite model = SqlHelper.MapEntity<Favorite>(reader);
                    return model;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region ��ѯ����ģ��ʵ�� +_User QuerySingleByIdX(string objectId,string columns){
        ///<summary>
        ///��ѯ����ģ��ʵ��
        ///</summary>
        ///<param name=favorites_id>����</param>);
        ///<returns>ʵ��</returns>);
        public Dictionary<string, object> QuerySingleByIdX(long favorites_id, object columns)
        {
            Dictionary<string, string[]> li;
            string[] clumns = new String[] { "favorites_id", "type", "favorites_title", "favorites_info", "image" };
            string[] cls = columns.parseColumnsX(clumns, "Favorite", out li);
            string sql = "SELECT TOP 1 " + string.Join(",", li["Favorite"]) + " from Favorite WHERE [objectId] = @objectId";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@favorites_id", favorites_id)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    Dictionary<string, object> model = SqlHelper.MapEntity(reader, cls);

                    return model;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region ��ѯ����ģ��ʵ�� +Users QuerySingleByWheres(object wheres)
        ///<summary>
        ///��ѯ����ģ��ʵ��
        ///</summary>
        ///<param name="wheres">����������</param>
        ///<returns>ʵ��</returns>
        public Favorite QuerySingleByWheres(object wheres)
        {
            var list = QueryList(1, 1, wheres);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
        }
        #endregion
        #region ��ѯ����ģ���м��� +Dictionary<string, object> QuerySingleByWheresX(object wheres,object columns)
        ///<summary>
        ///��ѯ����ģ��ʵ��
        ///</summary>
        ///<param name="wheres">����</param>
        ///<param name="columns">�м���</param>
        ///<returns>ʵ��</returns>
        public Dictionary<string, object> QuerySingleByWheresX(object wheres, object columns)
        {
            List<SqlParameter> list = null;
            string where = wheres.parseWheres(out list);
            where = string.IsNullOrEmpty(where) ? "" : " where " + where;
            Dictionary<string, string[]> li;
            string[] clumns = new String[] { "favorites_id", "type", "favorites_title", "favorites_info", "image" };
            string[] cls = columns.parseColumnsX(clumns, "Favorite", out li);
            string sql = "SELECT TOP 1 " + string.Join(",", li["Favorite"]) + " from Favorite" + where;
            using (var reader = SqlHelper.ExecuteReader(sql, list.ToArray()))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    Dictionary<string, object> model = SqlHelper.MapEntity(reader, cls);

                    return model;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region ��ҳ��ѯһ������ +IEnumerable<Users> QueryList(int index, int size, object wheres=null, string orderField=id, bool isDesc = true)
        ///<summary>
        ///��ҳ��ѯһ������
        ///</summary>
        ///<param name="index">ҳ��</param>
        ///<param name="size">ҳ��С</param>
        ///<param name="wheres">����������</param>
        ///<param name="orderField">�����ֶ�</param>
        ///<param name="isDesc">�Ƿ�������</param>
        ///<returns>ʵ�弯��</returns>
        public IEnumerable<Favorite> QueryList(int index, int size, object wheres = null, string orderField = "favorites_id", bool isDesc = true)
        {
            List<SqlParameter> list = null;
            string where = wheres.parseWheres(out list);
            orderField = string.IsNullOrEmpty(orderField) ? "favorites_id" : orderField;
            var sql = SqlHelper.GenerateQuerySql("Favorite", new string[] { "favorites_id", "type", "favorites_title", "favorites_info", "image" }, index, size, where, orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, list.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Favorite model = SqlHelper.MapEntity<Favorite>(reader);
                        yield return model;
                    }
                }
            }
        }
        #endregion
        #region ��ҳ��ѯһ������ +IEnumerable<Dictionary<string, object>> QueryListX(int index, int size, object columns = null, object wheres = null, string orderField=id, bool isDesc = true)
        ///<summary>
        ///��ҳ��ѯһ������
        ///</summary>
        ///<param name="index">ҳ��</param>
        ///<param name="size">ҳ��С</param>
        ///<param name="columns">ָ������</param>
        ///<param name="wheres">����������</param>
        ///<param name="orderField">�����ֶ�</param>
        ///<param name="isDesc">�Ƿ�������</param>
        ///<returns>ʵ�弯��</returns>
        public IEnumerable<Dictionary<string, object>> QueryListX(int index, int size, object columns = null, object wheres = null, string orderField = "favorites_id", bool isDesc = true)
        {
            List<SqlParameter> list = null;
            string where = wheres.parseWheres(out list);
            orderField = string.IsNullOrEmpty(orderField) ? "favorites_id" : orderField;
            Dictionary<string, string[]> li;
            string[] clumns = new String[] { "favorites_id", "type", "favorites_title", "favorites_info", "image" };
            string[] cls = columns.parseColumnsX(clumns, "Favorite", out li);
            var sql = SqlHelper.GenerateQuerySql("Favorite", li["Favorite"], index, size, where, orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, list.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> model = SqlHelper.MapEntity(reader, cls);

                        yield return model;
                    }
                }
            }
        }
        #endregion
        #region ���������޸�ָ���� +bool UpdateById(long favorites_id,object columns)
        /// <summary>
        /// ������������ָ����¼
        /// </summary>
        /// <param name="favorites_id">����</param>
        /// <param name="columns">�м��϶���</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool UpdateById(long favorites_id, object columns)
        {
            List<SqlParameter> list = null;
            string[] column = columns.parseColumns(out list);
            list.Add(new SqlParameter("@favorites_id", favorites_id.ToDBValue()));
            string sql = string.Format(@"UPDATE [dbo].[Favorite] SET  {0}  WHERE [{1}] = @{1}", string.Join(",", column), "favorites_id");
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray()) > 0;
        }
        #endregion
        #region �����������¼�¼+bool UpdateByWheres(object wheres, object columns)
        /// <summary>
        /// �����������¼�¼
        /// </summary>
        /// <param name="wheres">��������ʵ��ʵ��</param>
        /// <param name="columns">�м��϶���</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool UpdateByWheres(object wheres, object columns)
        {
            List<SqlParameter> list = null;
            string[] column = columns.parseColumns(out list);
            List<SqlParameter> list1 = null;
            string where = wheres.parseWheres(out list1);
            where = string.IsNullOrEmpty(where) ? string.Empty : "where " + where;
            list.AddRange(list1);
            string sql = string.Format(@"UPDATE [dbo].[Favorite] SET  {0} {1}", string.Join(",", column), where);
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray()) > 0;
        }
        #endregion
    }
}