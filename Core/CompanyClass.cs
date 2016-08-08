using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.IO;

namespace Core
{
    public class CompanyClass : Database
    {
        public Guid ID { get; set; }
        public string CompanyName {get;set;}
        public long Capital { get; set; }

        /*
        private string capitalStr;
        public string CapitalStr { get { return capitalStr; }
            set { capitalStr = t.LongStr2CapitalStr(value); }
        }
        */
        public string CapitalStr;

        public string Industry { get; set; }
        public int Area { get; set; }
        public string RoomNum { get; set; }
        public string Address { get; set; }
        public string Vector { get; set; }
        public string Introduction { get; set; }

        public string BusinessScope { get; set; }
        public string RegisteredAddress { get; set; }
        public string RegistrationDate { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Content { get; set; }

        protected Tools t;
        public CompanyClass()
        {
            t = new Tools();
        }

        /// <summary>
        /// 获取用户的账户类型
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回账户类型字符串</returns>
        public string GetAccountType(string username)
        {
            sql = "select 类型 from [用户视图] where 用户名=@username";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@username", username) }))
            {
                if (sdr.Read())
                    return sdr[0].ToString();
                else
                    return "";
               
            }
        }

        /// <summary>
        /// 添加企业基本信息
        /// </summary>
        /// <param name="username">添加企业的录入人</param>
        /// <returns>返回添加企业的ID</returns>
        public Guid AddCompanyBaseInformation(string username)
        {
            ID = Guid.NewGuid();
            int rtn = -1;
            sql = @"insert [企业] (ID,[企业名称],[注册资本],[行业],[物业面积],[房间号],[地址],[企业简介],[经营范围],[注册日期],[注册地],[联系人],[联系电话],[QQ],[电子邮箱],[内容],[载体],[录入人],[审核])
                values (@id,@companyName,@capital,@industry,@area,@roomNum,@address,@introduction,@businessScope,@registrationDate,@registeredAddress,@contact,@phone,@QQ,@email,@content,@Vector,@inputUser,@audit) ";
            rtn=ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter ("@id",ID),
                new SqlParameter("@companyName",CompanyName),
                new SqlParameter("@capital",Capital),
                new SqlParameter("@industry",Industry),
                new SqlParameter("@area",Area),
                new SqlParameter("@roomNum",RoomNum),
                new SqlParameter("@address",Address),
                new SqlParameter("@introduction",Introduction),
                new SqlParameter("@businessScope",BusinessScope),
                new SqlParameter("@registrationDate",RegistrationDate),
                new SqlParameter("@registeredAddress",RegisteredAddress),
                new SqlParameter("@contact",Contact),
                new SqlParameter("@phone",Phone),
                new SqlParameter("@QQ",QQ),
                new SqlParameter("@email",Email),
                new SqlParameter("@Vector",Vector),
                new SqlParameter("@content",Content),
                new SqlParameter("@inputUser",username),

                //新添加的企业审核状态设为“添加未审核”
                new SqlParameter("@audit",1)
            });

            if (rtn == 1)
                return ID;
            else
                return Guid.Empty;
        }

        /// <summary>
        /// 从当前类中的数据更新数据库中的企业基本信息
        /// </summary>
        /// <returns>返回是否更新成功</returns>
        public bool UpdateCompanyInfo()
        {
            int rtn;
            sql = @"update [企业] set [企业名称]=@companyName,[注册资本]=@capital,[行业]=@industry,[物业面积]=@area,[房间号]=@roomNum,[地址]=@address,
                [企业简介]=@introduction,[经营范围]=@businessScope,[注册日期]=@registrationDate,[注册地]=@registeredAddress,[联系人]=@contact,[联系电话]=@phone,[QQ]=@QQ,[电子邮箱]=@email,[内容]=@content,[载体]=@Vector,[审核]=@audit
                where ID=@id";

            rtn = ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter ("@id",ID),
                new SqlParameter("@companyName",CompanyName),
                new SqlParameter("@capital",Capital),
                new SqlParameter("@industry",Industry),
                new SqlParameter("@area",Area),
                new SqlParameter("@roomNum",RoomNum),
                new SqlParameter("@address",Address),
                new SqlParameter("@introduction",Introduction),
                new SqlParameter("@businessScope",BusinessScope),
                new SqlParameter("@registrationDate",RegistrationDate),
                new SqlParameter("@registeredAddress",RegisteredAddress),
                new SqlParameter("@contact",Contact),
                new SqlParameter("@phone",Phone),
                new SqlParameter("@QQ",QQ),
                new SqlParameter("@email",Email),
                new SqlParameter("@Vector",Vector),
                new SqlParameter("@content",Content),

                //新添加的企业审核状态设为“修改未审核”
                new SqlParameter("@audit",2)
            });

            if (rtn == 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 从数据库中填充企业基本信息到当前类中,此处用于填充到Textbox中，所以无需用HtmlEncode转换为网页编码
        /// </summary>
        /// <param name="companyID">要填充的企业ID</param>
        /// <returns>返回是否填充成功</returns>
        public bool FillCompanyInfo(Guid companyID)
        {
            sql = "select * from 企业 where ID=@comID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@comID", companyID) }))
            {
                if (!sdr.Read())
                    return false;
                CompanyName = sdr["企业名称"].ToString();
                long b;
                long.TryParse(sdr["注册资本"].ToString(),out b);

                Capital = b;
                Industry = sdr["行业"].ToString();

                int a;
                int.TryParse(sdr["物业面积"].ToString(),out a);
                Area = a;

                RoomNum = sdr["房间号"].ToString();
                Address = sdr["地址"].ToString();
                Introduction = sdr["企业简介"].ToString();
                BusinessScope = sdr["经营范围"].ToString();

                //此处Datetime需要转化一下
                RegistrationDate = DateTime.Parse(sdr["注册日期"].ToString()).ToString("yyyy-MM-dd");
                RegisteredAddress = sdr["注册地"].ToString();
                Contact = sdr["联系人"].ToString();
                Phone = sdr["联系电话"].ToString();
                QQ = sdr["QQ"].ToString();
                Email = sdr["电子邮箱"].ToString();
                Content = sdr["内容"].ToString();
                Vector = sdr["载体"].ToString();

            }
            return true;

        }

        /// <summary>
        /// 将企业视图中的用户显示的数据填充到类属性中（由于直接用于客户端显示，所有的内容一般需经过HtmlEncode转换）
        /// </summary>
        /// <param name="companyID">要填充的企业ID</param>
        /// <returns>返回是否填充成功</returns>
        public bool FillCompanyInfoView(Guid companyID)
        {
            sql = "select * from 企业视图 where ID=@comID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@comID", companyID) }))
            {
                if (!sdr.Read())
                    return false;


                CompanyName = HttpUtility.HtmlEncode(sdr["企业名称"].ToString());
                /*
                long b;
                long.TryParse(sdr["注册资本"].ToString(), out b);
                Capital = b;
                CapitalStr = Capital.ToString();//此处多了一步，需将长整型数字字符串处理成带单位可以显示的字符串
                */
                CapitalStr = t.LongStr2CapitalStr(sdr["注册资本"].ToString());

                Industry = HttpUtility.HtmlEncode(sdr["行业"].ToString());

                int a;
                int.TryParse(sdr["物业面积"].ToString(), out a);
                Area = a;

                RoomNum = HttpUtility.HtmlEncode(sdr["房间号"].ToString());
                Address = HttpUtility.HtmlEncode(sdr["地址"].ToString());
                Introduction = HttpUtility.HtmlEncode(sdr["企业简介"].ToString());
                BusinessScope = HttpUtility.HtmlEncode(sdr["经营范围"].ToString());

                //此处Datetime需要转化一下
                RegistrationDate = DateTime.Parse(sdr["注册日期"].ToString()).ToString("yyyy-MM-dd");
                if (RegistrationDate == "1900-01-01")
                    RegistrationDate = string.Empty;

                RegisteredAddress = HttpUtility.HtmlEncode(sdr["注册地"].ToString());
                Contact = HttpUtility.HtmlEncode(sdr["联系人"].ToString());
                Phone = HttpUtility.HtmlEncode(sdr["联系电话"].ToString());
                QQ = HttpUtility.HtmlEncode(sdr["QQ"].ToString());
                Email = HttpUtility.HtmlEncode(sdr["电子邮箱"].ToString());
                Content = sdr["内容"].ToString();//此处无需处理HTMLEncode，因添加时xheditor控件已处理
                Vector = sdr["载体名称"].ToString();//此处在录入时只能是数字

            }
            return true;

        }

        /// <summary>
        /// 获取企业滚动的宣传页，并处理为绑定翻页显示控件提供数据源
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>包含该企业图片类型为“企业宣传内容”的所有图片地址</returns>
        public DataSet GetCompanyAdvertises(Guid companyID)
        {
            //选择属于CompanyID并且是企业宣传图片的所有图片
            sql = "select 图片地址 from 企业图片 where 所属企业=@comID and 图片类型=1";
            DataSet ds = GetDataSet(sql, new SqlParameter[] { new SqlParameter("@comID", companyID) });

            //添加页码列
            ds.Tables[0].Columns.Add("Num");

            //如果企业没有宣传图片则显示默认没有图片
            if (ds.Tables[0].Rows.Count<1)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["图片地址"] = "~/Images/noImg.jpg";
                dr["Num"] = 1;
                ds.Tables[0].Rows.Add(dr);
                return ds;
            }

            //添加页码列数据
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                ds.Tables[0].Rows[i]["Num"] = i+1;

            return ds;
        }

        /// <summary>
        /// 返回企业包含的图片类型
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>返回包含图片类型的Dataset</returns>
        public DataSet GetPicKind(Guid companyID)
        {
            sql = "select distinct(图片类型),类型名称 from 企业图片视图 where 图片类型>1 and 所属企业=@comID";
            return GetDataSet(sql,new SqlParameter[] { new SqlParameter("@comID", companyID) });
        }

        /// <summary>
        /// 获得相应企业相应类型的图片
        /// </summary>
        /// <param name="companyID">企业的ID</param>
        /// <param name="picType">图片类型</param>
        /// <returns>返回Dataset</returns>
        public DataSet GetPicShowAddress(Guid companyID,int picType)
        {
            sql = "select 图片地址 from 企业图片视图 where 图片类型>1 and 所属企业=@comID and 图片类型=@picType";
            return GetDataSet(sql, new SqlParameter[] { new SqlParameter("@comID", companyID),
            new SqlParameter("@picType",picType)
            });
        }

        /// <summary>
        /// 根据企业ID返回企业的名称（一般给别的类用）//已经过HTMLEncode处理
        /// </summary>
        /// <param name="ID">企业ID</param>
        /// <returns>返回的企业名称</returns>
        public string GetCompanyName(Guid ID)
        {
            sql = "select 企业名称 from 企业视图 where ID=@ID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@ID", ID) }))
                if (sdr.Read())
                    return HttpUtility.HtmlEncode(sdr[0].ToString());
                else
                    return string.Empty;
        }

        /// <summary>
        /// 删除企业记录（包括所有评论、图片、解释等内容）
        /// </summary>
        /// <param name="companyID">要删除的企业ID</param>
        /// <returns>返回是否删除成功</returns>
        public bool DelCompany(Guid companyID)
        {
            //首先记录下数据库中当前企业的所有图片（文件）信息，以备在成功删除数据库中记录信息后删除该企业的所有图片（文件）
            List<string> picList = GetPicList(companyID);

            //最后删除数据库中企业所有信息
            sql = @"delete from 解释 where 解释.所属评论 in (select ID from 评论 where 所属企业=@companyID)
                   delete from 评论图片 where 评论图片.所属评论 in (select ID from 评论 where 所属企业=@companyID)
                    delete from 企业图片 where 企业图片.所属企业=@companyID
                    delete from 评论 where 所属企业=@companyID
                    delete from 企业 where ID=@companyID";
            bool result = ExecuteTranSQL(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) });


            if (result)
                DelPicFiles(picList);
             
            return result;
        }

        public bool DelPicFiles(List<string> picList)
        {
            FileInfo file;
            foreach(string filepath in picList)
            {
                file = new FileInfo(filepath);
                if(file.Exists)
                {
                    file.Attributes = FileAttributes.Normal;
                    file.Delete();
                }

                string dir = filepath.Substring(0, filepath.LastIndexOf("\\"));
                if (Directory.GetFiles(dir).Length + Directory.GetDirectories(dir).Length == 0)
                {
                    //如果目录为空则删除目录
                    Directory.Delete(dir);
                }
            }
            return true;
        }

        /// <summary>
        /// 获取企业所有图片地址（以备在成功删除数据库中记录信息后删除该企业的所有图片（文件））
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <returns>返回一个包含所有图片地址的列表</returns>
        public List<string> GetPicList(Guid companyID)
        {
            //第一步先搜索企业宣传内容里是否有上传图片
            List<string> picList = GetContentPicList(companyID);

            //第二步搜索企业的上传图片
            sql = "select 图片地址 from 企业图片 where 企业图片.所属企业=@companyID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) }))
            {
                while(sdr.Read())
                {
                    picList.Add(HttpContext.Current.Server.MapPath(sdr[0].ToString()));
                }
                    
            }

            //第三步搜索企业评论里上传的图片
            sql = "select 图片地址 from 评论图片 where 评论图片.所属评论 in (select ID from 评论 where 所属企业=@companyID)";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@companyID", companyID) }))
            {
                while (sdr.Read())
                {
                    picList.Add(HttpContext.Current.Server.MapPath(sdr[0].ToString()));
                }

            }
            return picList;
        }
        

        /// <summary>
        /// 获取企业宣传内容文本中含有上传图片地址的列表集合
        /// </summary>
        /// <param name="companyID">企业的ID</param>
        /// <returns>返回包含上传图片地址的列表集合（以备下一步删除用，所以系统包括的图标不在此列)</returns>
        public List<string> GetContentPicList(Guid companyID)
        {
            List<string> contentPicList=new List<string>();
            string content;
            
            sql = "select 内容 from 企业 where ID=@ID";
            using (SqlDataReader sdr = GetDataReader(sql, new SqlParameter[] { new SqlParameter("@ID", companyID) }))
            {
                if (sdr.Read())
                {
                    content = sdr[0].ToString();
                    GeneratePicList(content,ref contentPicList);
                }

            }
            return contentPicList;
        }

        /// <summary>
        /// 根据内容文本，填充上传图片地址列表
        /// </summary>
        /// <param name="content">企业宣传内容文本</param>
        /// <param name="l">引用的上传图片地址列表</param>
        /// <returns>返回是否有数据填充</returns>
        public bool GeneratePicList(string content,ref List<string> l)
        {
            bool result = false;
            int start, end;
            string img, src;
            start = content.IndexOf("<img");
            while (start != -1)
            {
                end = content.IndexOf("/>", start);
                img = content.Substring(start + 4, end - start - 4);
                if (img.IndexOf("Upload/ContentUploadPic") != -1)
                {
                    src=GetSrc(img);
                    l.Add(HttpContext.Current.Server.MapPath(src));
                    if (!result)
                        result = true;

                }
                start = content.IndexOf("<img", end + 2);
            }
            return result;
        }

        /// <summary>
        /// 从src参数内取出图片地址
        /// </summary>
        /// <param name="s">img标签中的内容</param>
        /// <returns>返回图片地址</returns>
        public string GetSrc(string s)
        {
            int imgstart, imgend;
            imgstart = s.IndexOf("src") + 5;
            imgend = s.IndexOf("\"", imgstart);
            return s.Substring(imgstart, imgend - imgstart);
        }

        /// <summary>
        /// 提交企业错误信息
        /// </summary>
        /// <param name="companyID">企业ID</param>
        /// <param name="content">报告错误内容（已经过HtmlEncode处理）</param>
        /// <param name="username">用户名</param>
        /// <returns>返回是否成功</returns>
        public bool SubmitCompanyError(Guid companyID,string content,string username)
        {
            sql = "insert into 企业问题报告(ID,问题企业,问题内容,录入人) values (@ID,@companyID,@content,@username)";
            Guid ID = Guid.NewGuid();
            int rtn = ExecuteSql(sql, new SqlParameter[]
            {
                new SqlParameter("@ID",ID),
                new SqlParameter("@companyID",companyID),
                new SqlParameter("@content",HttpUtility.HtmlEncode(content)),
                new SqlParameter("@username",username)
            });

            if (rtn == 1)
                return true;
            else
                return false;
        }
    }
}
