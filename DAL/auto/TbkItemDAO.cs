using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using MvcApplication1.Model;
using MvcApplication1.Utility;
using System.Text;

namespace MvcApplication1.DAO
{
    public partial class TbkItemDAO
    {
        #region �����ݿ������һ����¼ +bool Insert(TbkItem model)
        ///<summary>
        ///�����ݿ������һ����¼
        ///</summary>
        ///<param name="model">Ҫ��ӵ�ʵ��</param>
        public bool Insert(TbkItem model)
        {
            const string sql = @"INSERT INTO [dbo].[TbkItem] (num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url,nick,seller_id,volume) VALUES (@num_iid,@title,@pict_url,@small_images,@reserve_price,@zk_final_price,@user_type,@provcity,@item_url,@nick,@seller_id,@volume)";
            int res = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@num_iid", model.num_iid.ToDBValue()), new SqlParameter("@title", model.title.ToDBValue()), new SqlParameter("@pict_url", model.pict_url.ToDBValue()), new SqlParameter("@small_images", model.small_images.ToDBValue()), new SqlParameter("@reserve_price", model.reserve_price.ToDBValue()), new SqlParameter("@zk_final_price", model.zk_final_price.ToDBValue()), new SqlParameter("@user_type", model.user_type.ToDBValue()), new SqlParameter("@provcity", model.provcity.ToDBValue()), new SqlParameter("@item_url", model.item_url.ToDBValue()), new SqlParameter("@nick", model.nick.ToDBValue()), new SqlParameter("@seller_id", model.seller_id.ToDBValue()), new SqlParameter("@volume", model.volume.ToDBValue()));
            return res > 0;
        }

        public bool InsertSome(List<TbkItem> itemList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO [dbo].[TbkItem] (num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url,nick,seller_id,volume) VALUES ");
            int length = itemList.Count();
            for (int i = 0; i < length; i++)
            {
                sb.Append("(@num_iid_" + i);
                sb.Append(",@title_" + i);
                sb.Append(",@pict_url_" + i);
                sb.Append(",@small_images_" + i);
                sb.Append(",@reserve_price_" + i);
                sb.Append(",@zk_final_price_" + i);
                sb.Append(",@user_type_" + i);
                sb.Append(",@provcity_" + i);
                sb.Append(",@item_url_" + i);
                sb.Append(",@nick_" + i);
                sb.Append(",@seller_id_" + i);
                if (i == length - 1)
                    sb.Append(",@volume_" + i + ")");
                else
                    sb.Append(",@volume_" + i + "),");
            }
            string sql = sb.ToString();
            List<SqlParameter> param = new List<SqlParameter>();
            int j = 0;
            foreach (TbkItem model in itemList)
            {
                param.Add(new SqlParameter("@num_iid_" + j, model.num_iid.ToDBValue()));
                param.Add(new SqlParameter("@title_" + j, model.title.ToDBValue()));
                param.Add(new SqlParameter("@pict_url_" + j, model.pict_url.ToDBValue()));
                param.Add(new SqlParameter("@small_images_" + j, model.small_images.ToDBValue()));
                param.Add(new SqlParameter("@reserve_price_" + j, model.reserve_price.ToDBValue()));
                param.Add(new SqlParameter("@zk_final_price_" + j, model.zk_final_price.ToDBValue()));
                param.Add(new SqlParameter("@user_type_" + j, model.user_type.ToDBValue()));
                param.Add(new SqlParameter("@provcity_" + j, model.provcity.ToDBValue()));
                param.Add(new SqlParameter("@item_url_" + j, model.item_url.ToDBValue()));
                param.Add(new SqlParameter("@nick_" + j, model.nick.ToDBValue()));
                param.Add(new SqlParameter("@seller_id_" + j, model.seller_id.ToDBValue()));
                param.Add(new SqlParameter("@volume_" + j, model.volume.ToDBValue()));
                j++;
            }
            int res = SqlHelper.ExecuteNonQuery(sql, param.ToArray());
            return res > 0;
        }
        #endregion
        #region ɾ��һ����¼ +bool Delete(long num_iid)
        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="num_iid">����</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool Delete(long num_iid)
        {
            const string sql = "DELETE FROM [dbo].[TbkItem] WHERE [num_iid] = @num_iid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@num_iid", num_iid)) > 0;
        }
        /// <summary>
        /// ɾ�����м�¼
        /// </summary>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool DeleteAll()
        {
            const string sql = "truncate table [dbo].[TbkItem]";
            //const string sql = "DELETE FROM [dbo].[FavoriteItem]";
            return SqlHelper.ExecuteNonQuery(sql, null) == -1;
        }
        #endregion
        #region ��������ID����һ����¼ +bool Update(TbkItem model)
        /// <summary>
        /// ������������һ����¼
        /// </summary>
        /// <param name="model">���º��ʵ��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool Update(TbkItem model)
        {
            const string sql = @"UPDATE [dbo].[TbkItem] SET  title=@title,pict_url=@pict_url,small_images=@small_images,reserve_price=@reserve_price,zk_final_price=@zk_final_price,user_type=@user_type,provcity=@provcity,item_url=@item_url,nick=@nick,seller_id=@seller_id,volume=@volume  WHERE [num_iid] = @num_iid";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@num_iid", model.num_iid.ToDBValue()), new SqlParameter("@title", model.title.ToDBValue()), new SqlParameter("@pict_url", model.pict_url.ToDBValue()), new SqlParameter("@small_images", model.small_images.ToDBValue()), new SqlParameter("@reserve_price", model.reserve_price.ToDBValue()), new SqlParameter("@zk_final_price", model.zk_final_price.ToDBValue()), new SqlParameter("@user_type", model.user_type.ToDBValue()), new SqlParameter("@provcity", model.provcity.ToDBValue()), new SqlParameter("@item_url", model.item_url.ToDBValue()), new SqlParameter("@nick", model.nick.ToDBValue()), new SqlParameter("@seller_id", model.seller_id.ToDBValue()), new SqlParameter("@volume", model.volume.ToDBValue())) > 0;
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
            string sql = "SELECT COUNT(1) from TbkItem " + str; var res = SqlHelper.ExecuteScalar(sql, list.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion
        #region ��ѯ����ģ��ʵ�� +TbkItem QuerySingleById(long num_iid)
        /// <summary>
        /// ��ѯ����ģ��ʵ��
        /// </summary>
        /// <param name="id">num_iid</param>);
        /// <returns>ʵ��</returns>);
        public TbkItem QuerySingleById(long num_iid)
        {
            const string sql = "SELECT TOP 1 num_iid,title,pict_url,small_images,reserve_price,zk_final_price,user_type,provcity,item_url,nick,seller_id,volume from TbkItem WHERE [num_iid] = @num_iid";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@num_iid", num_iid)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    TbkItem model = SqlHelper.MapEntity<TbkItem>(reader);
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
        ///<param name=num_iid>����</param>);
        ///<returns>ʵ��</returns>);
        public Dictionary<string, object> QuerySingleByIdX(long num_iid, object columns)
        {
            Dictionary<string, string[]> li;
            string[] clumns = new String[] { "num_iid", "title", "pict_url", "small_images", "reserve_price", "zk_final_price", "user_type", "provcity", "item_url", "nick", "seller_id", "volume" };
            string[] cls = columns.parseColumnsX(clumns, "TbkItem", out li);
            string sql = "SELECT TOP 1 " + string.Join(",", li["TbkItem"]) + " from TbkItem WHERE [objectId] = @objectId";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@num_iid", num_iid)))
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
        public TbkItem QuerySingleByWheres(object wheres)
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
            string[] clumns = new String[] { "num_iid", "title", "pict_url", "small_images", "reserve_price", "zk_final_price", "user_type", "provcity", "item_url", "nick", "seller_id", "volume" };
            string[] cls = columns.parseColumnsX(clumns, "TbkItem", out li);
            string sql = "SELECT TOP 1 " + string.Join(",", li["TbkItem"]) + " from TbkItem" + where;
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
        public IEnumerable<TbkItem> QueryList(int index, int size, object wheres = null, string orderField = "uuid", bool isDesc = true)
        {
            List<SqlParameter> list = null;
            string where = wheres.parseWheres(out list);
            orderField = string.IsNullOrEmpty(orderField) ? "uuid" : orderField;
            var sql = SqlHelper.GenerateQuerySql("TbkItem", new string[] { "num_iid", "title", "pict_url", "small_images", "reserve_price", "zk_final_price", "user_type", "provcity", "item_url", "nick", "seller_id", "volume" }, index, size, where, orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, list.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TbkItem model = SqlHelper.MapEntity<TbkItem>(reader);
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
        public IEnumerable<Dictionary<string, object>> QueryListX(int index, int size, object columns = null, object wheres = null, string orderField = "num_iid", bool isDesc = true)
        {
            List<SqlParameter> list = null;
            string where = wheres.parseWheres(out list);
            orderField = string.IsNullOrEmpty(orderField) ? "num_iid" : orderField;
            Dictionary<string, string[]> li;
            string[] clumns = new String[] { "num_iid", "title", "pict_url", "small_images", "reserve_price", "zk_final_price", "user_type", "provcity", "item_url", "nick", "seller_id", "volume" };
            string[] cls = columns.parseColumnsX(clumns, "TbkItem", out li);
            var sql = SqlHelper.GenerateQuerySql("TbkItem", li["TbkItem"], index, size, where, orderField, isDesc);
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
        #region ���������޸�ָ���� +bool UpdateById(long num_iid,object columns)
        /// <summary>
        /// ������������ָ����¼
        /// </summary>
        /// <param name="num_iid">����</param>
        /// <param name="columns">�м��϶���</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool UpdateById(long num_iid, object columns)
        {
            List<SqlParameter> list = null;
            string[] column = columns.parseColumns(out list);
            list.Add(new SqlParameter("@num_iid", num_iid.ToDBValue()));
            string sql = string.Format(@"UPDATE [dbo].[TbkItem] SET  {0}  WHERE [{1}] = @{1}", string.Join(",", column), "num_iid");
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
            string sql = string.Format(@"UPDATE [dbo].[TbkItem] SET  {0} {1}", string.Join(",", column), where);
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray()) > 0;
        }
        #endregion
    }
}